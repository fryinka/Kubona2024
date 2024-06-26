using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kubona.Data.Models;
using ReturnTrue.AspNetCore.Identity.Anonymous;
using System.Text;
using Microsoft.Extensions.Options;
using System.Net.Http;
using Kubona.Data.Helper;
using RestSharp;
using Newtonsoft.Json;

namespace Kubona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private readonly BuyAWatchContext _context;
        private readonly IOptions<WebsiteSettings> _appSettings;

        public CheckOutController(BuyAWatchContext context, IOptions<WebsiteSettings> options)
        {
            _context = context;
            _appSettings = options;
        }

        // POST: api/CheckOut
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<CheckOutDTO> PostTfOrderProductLogger(CheckOutUserDTO checkOutUser)
        {
            string gclid = checkOutUser.gclid;
            string fbclid = checkOutUser.fbclid;
            string userId = null;
            CheckOutDTO checkoutDTO = new CheckOutDTO();

            IAnonymousIdFeature feature = HttpContext.Features.Get<IAnonymousIdFeature>();
            if (feature != null)
            {
                userId = feature.AnonymousId;
            }

            var orderId = GetOrderId(userId);
            //read from appsetting.json
            string customerPhone = _appSettings.Value.Customergsm;
            string servicePhone = _appSettings.Value.Servicegsm;
            int serviceSwitch = _appSettings.Value.ServiceSwitch;

            if (serviceSwitch == 2)
            {
                servicePhone = _appSettings.Value.Servicegsm2;
            }
            else if (serviceSwitch == 3)
            {
                servicePhone = _appSettings.Value.Servicegsm3;
            }


            if (orderId > 0)
            {
                checkoutDTO.orderId = orderId;
                if (!string.IsNullOrEmpty(checkOutUser.customerGSM))
                {
                    customerPhone = checkOutUser.customerGSM;

                    if (IsExistingCustomer(customerPhone))
                    {
                        //read form appsetting.json
                        servicePhone = _appSettings.Value.Servicegsm;
                    }
                }
                var cTfOrderLoggerA = await _context.TfOrderProductLoggers.Where(e => e.OrderId == orderId).FirstOrDefaultAsync();
                if (cTfOrderLoggerA != null)
                {
                    cTfOrderLoggerA.DeviceSource = checkOutUser.source;
                    cTfOrderLoggerA.StateId = 1;
                    cTfOrderLoggerA.OnlineNotes = System.Guid.NewGuid().ToString("N").Substring(0, 5);
                    cTfOrderLoggerA.CustomerGsm = checkOutUser.customerGSM;
                    cTfOrderLoggerA.CurrentStatus = (int?)kubonaEnums.orderLoggerStatus.identified;
                    _context.Entry(cTfOrderLoggerA).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }

                var shipToId = GetShipToId(userId);

                var cTfOrderProduct = _context.TfOrderProducts.Where(e => e.OrderId == orderId).FirstOrDefault();
                if (cTfOrderProduct != null)
                {
                    cTfOrderProduct.Gclid = gclid;
                    cTfOrderProduct.Fbclid = fbclid;
                    cTfOrderProduct.ShipToId = shipToId;
                    _context.Entry(cTfOrderProduct).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }

                var cTfOrderProductLogger = _context.TfOrderProductLoggers.Where(e => e.OrderId == orderId).FirstOrDefault();
                if (cTfOrderProductLogger != null)
                {
                    cTfOrderProductLogger.CurrentStatus = checkOutUser.exist == true ? (int?)kubonaEnums.orderLoggerStatus.checkout : (int?)kubonaEnums.orderLoggerStatus.new_checkout;
                    cTfOrderProductLogger.CityId = 1;
                    cTfOrderProductLogger.CheckoutDate = DateTime.Now;
                    _context.Entry(cTfOrderProductLogger).State = EntityState.Modified;
                    //await _context.SaveChangesAsync();

                    //save user's payment option and orderId to DB
                    var existingOrder = await _context.TfOrderPaymentOptions.FindAsync(checkoutDTO.orderId);

                    if (existingOrder == null)
                    {
                        var paymentOption = new TfOrderPaymentOptions() { OrderId = checkoutDTO.orderId, PaymentOption = checkOutUser.paymentOption };
                        await _context.TfOrderPaymentOptions.AddAsync(paymentOption);
                    }
                    await _context.SaveChangesAsync();
                    checkoutDTO.whatsAppUrl = WhatsAppUrl(checkOutUser.total, checkOutUser.exist, orderId, servicePhone, checkOutUser.paymentOption);
                }
            }

            return checkoutDTO;
        }


        [HttpGet("Existing")]
        public bool CheckExistingCustomer(string customerGsm)
        {
            var tr = _context.TfOrderProductLoggers.FirstOrDefault(x => x.CustomerGsm == customerGsm && x.CurrentStatus == (int)kubonaEnums.orderLoggerStatus.checkout);
            if (tr != null)
            {
                return true;
            }
            else return false;
        }


        [HttpGet("GetOrderInfo")]
        public async Task<OrderInfo> GetInfo()
        {
            OrderInfo info = new OrderInfo();
            string userId = null;
            IAnonymousIdFeature feature = HttpContext.Features.Get<IAnonymousIdFeature>();
            if (feature != null)
            {
                userId = feature.AnonymousId;
            }

            var orderInfo = await _context.TfOrderProducts.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            info.OrderId = orderInfo.OrderId;
            info.Total = (decimal)orderInfo.OrderAmount;
            return info;
        }

        [HttpPost("Verify")]
        public async Task<CheckOutDTO> VerifyAmount(VerifyDTO verifyDTO)
        {
            //read from appsetting.json
            string customerPhone = _appSettings.Value.Customergsm;
            string servicePhone = _appSettings.Value.Servicegsm;
            int serviceSwitch = _appSettings.Value.ServiceSwitch;
            CheckOutDTO checkoutDTO = new CheckOutDTO();
            int checkout = (int)kubonaEnums.orderLoggerStatus.checkout;

            if (serviceSwitch == 2)
            {
                servicePhone = _appSettings.Value.Servicegsm2;
            }
            else if (serviceSwitch == 3)
            {
                servicePhone = _appSettings.Value.Servicegsm3;
            }

            var check = await _context.TFNewCustOrderVerifies.FirstOrDefaultAsync(x => x.OrderId == verifyDTO.OrderId);
            if (check == null)
            {
                var verCust = new TFNewCustOrderVerify()
                {
                    OrderId = verifyDTO.OrderId,
                    AmountEntered = verifyDTO.AmountEntered
                };
                await _context.TFNewCustOrderVerifies.AddAsync(verCust);
                await _context.SaveChangesAsync();

                var orderLogged = await _context.TfOrderProductLoggers.FirstOrDefaultAsync(x => x.OrderId == verifyDTO.OrderId);
                if (orderLogged != null && verifyDTO.Correct == true)
                {
                    orderLogged.CurrentStatus = checkout;
                    _context.Entry(orderLogged).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }

                checkoutDTO.whatsAppUrl = WhatsAppUrl(verifyDTO.OrderAmt, verifyDTO.Correct, verifyDTO.OrderId, servicePhone, verifyDTO.PaymentOption);
            }

            return checkoutDTO;
        }

        [HttpGet("WhatsApp")]
        public async Task<bool> WhatsAppVerify(string phone)
        {
            string apiUrl = _appSettings.Value.WhatsappVerifyApiUrl;
            string apiToken = _appSettings.Value.WhatsappVerifyApiToken;
            var WaPhone = AttributeHelper.ConvertToInternationalFormat(phone);
            var result = _context.TfWhatsAppVerifies.Where(x => x.Phone == WaPhone).FirstOrDefault();
            if (result != null)
            {
                return result.Status == "valid" ? true : false;
            }
            else
            {
                //Verify on WhatsApp and log result
                var url = apiUrl;
                var client = new RestClient(url);
                var request = new RestRequest(url, Method.Get);
                request.AddHeader("content-type", "application/json");
                request.AddParameter("token", apiToken);
                request.AddParameter("chatId", WaPhone);
                request.AddParameter("nocache", "");
                RestResponse response = await client.ExecuteAsync(request);
                UltraMsgDTO output = JsonConvert.DeserializeObject<UltraMsgDTO>(response.Content);

                //log the result on the db
                TfWhatsAppVerify tfWhatsAppVerify = new TfWhatsAppVerify()
                {
                    Phone = WaPhone,
                    Status = output.status,
                    DateSent = DateTime.Now
                };
                await _context.TfWhatsAppVerifies.AddAsync(tfWhatsAppVerify);
                _context.SaveChanges();
                return tfWhatsAppVerify.Status == "valid" ? true : false;
            }
        }

        private string WhatsAppUrl(decimal amount, bool check, int orderId, string servicePhone, int paymentOption)
        {
            StringBuilder destinationUrl = new StringBuilder();
            string newT = null;
            if (check == true)
            {
                destinationUrl.AppendFormat("https://api.whatsapp.com/send?phone={0}&text=Please-Process-Order-{1}-{2}-{3}", servicePhone, Math.Ceiling(amount), orderId, paymentOption);
            }
            else
            {
                destinationUrl.AppendFormat("https://api.whatsapp.com/send?phone={0}&text=Please-Process-NewOrder-{1}-{2}-{3}", servicePhone, Math.Ceiling(amount), orderId, paymentOption);
            }
            newT = ShortenUrl(destinationUrl.ToString()).Result;

            return newT != null ? newT : destinationUrl.ToString();
        }
        private bool TfOrderProductLoggerExists(int id)
        {
            return _context.TfOrderProductLoggers.Any(e => e.OrderId == id);
        }

        private bool IsExistingCustomer(string gsm)
        {
            return _context.TfSalesLogs.Any(e => e.Gsm == gsm);
        }

        private int GetShipToId(string userId)
        {
            var sShipTo = _context.TfShipToAddresses.Where(e => e.UserId == userId).FirstOrDefault();
            int shipToId = 0;
            if (sShipTo == null)
            {
                sShipTo = new TfShipToAddress
                {
                    State = 1,
                    Email = "NoEmail",
                    UserId = userId,
                    DeliverTo = "NoName"
                };
                _context.TfShipToAddresses.Add(sShipTo);
                _context.SaveChanges();
                shipToId = sShipTo.ShipToId;
            }
            else
            {
                shipToId = sShipTo.ShipToId;
            }
            return shipToId;
        }

        private int GetOrderId(string userId)
        {
            var tfOrderProductLoggers = _context.TfOrderProductLoggers
                  .Where(m => m.CurrentStatus < (int?)kubonaEnums.orderLoggerStatus.checkout)
                  .Join(_context.TfOrderProducts.Where(n => n.UserId == userId), m => m.OrderId, n => n.OrderId,
                  (o, m) => new
                  {
                      orderId = o.OrderId,
                      userId = m.UserId
                  }
                  ).FirstOrDefault();

            if (tfOrderProductLoggers == null)
            {
                return 0;
            }
            else
            {
                return tfOrderProductLoggers.orderId;
            }

        }

        //private async Task<bool> WhatsAppVerify(string phone)
        //{
        //    string apiUrl = _appSettings.Value.UrlShortenerUrl;
        //    string apiToken = _appSettings.Value.WhatsappVerifyApiToken;
        //    var WaPhone = AttributeHelper.ConvertToInternationalFormat(phone);
        //    var result = _context.TfWhatsAppVerifies.Where(x => x.Phone == phone).FirstOrDefault();
        //    if (result != null)
        //    {
        //        return result.Status == "valid" ? true : false;
        //    }
        //    else
        //    {
        //        //Verify on WhatsApp and log result

        //        var url = apiUrl;
        //        var client = new RestClient(url);
        //        var request = new RestRequest(url, Method.Get);
        //        request.AddHeader("content-type", "application/json");
        //        request.AddParameter("token", apiToken);
        //        request.AddParameter("chatId", WaPhone);
        //        request.AddParameter("nocache", "");
        //        RestResponse response = await client.ExecuteAsync(request);
        //        var output = response.Content;

        //        //log the result on the db
        //        TfWhatsAppVerify tfWhatsAppVerify = new TfWhatsAppVerify()
        //        {
        //            Phone = WaPhone,
        //            Status = output,
        //            DateSent = DateTime.Now
        //        };
        //        await _context.TfWhatsAppVerifies.AddAsync(tfWhatsAppVerify);
        //        _context.SaveChanges();
        //        return tfWhatsAppVerify.Status == "valid" ? true : false;
        //    }
        //}
        private async Task<string> ShortenUrl(string url)
        {
            var client = new HttpClient();
            string body = null;
            string uri = _appSettings.Value.UrlShortenerUrl;
            string key = _appSettings.Value.UrlShortenerKey;
            string host = _appSettings.Value.UrlShortenerHost;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri),
                Headers =
                    {
                        { "X-RapidAPI-Key", key },
                        { "X-RapidAPI-Host", host },
                    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        { "url", url },
                    }),
            };
            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    body = await response.Content.ReadAsStringAsync();
                }
                else
                    body = null;
            }
            //return null if statuscode is 400
            return body != null ? body.Replace("{\"result_url\":\"", "").Replace("\"}", "") : null;
        }

    }
}

