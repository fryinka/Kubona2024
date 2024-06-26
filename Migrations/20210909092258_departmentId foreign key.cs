using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kubona.Migrations
{
    public partial class departmentIdforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_BigCommerceMigration",
                columns: table => new
                {
                    TrackingId = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    Title = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: true),
                    Body = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    StyleTag = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    ColorTag = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    ImagePosition = table.Column<int>(type: "int", nullable: true),
                    ImageSrc = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    SizeDesc = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    internetprice = table.Column<decimal>(type: "money", nullable: true),
                    storeprice = table.Column<decimal>(type: "money", nullable: true),
                    vTrackingid = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    vQuantity = table.Column<int>(type: "int", nullable: true),
                    image1Src = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    image2Src = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    image3Src = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    image4Src = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    image5Src = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    image6Src = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    image7Src = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    image8Src = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    counter = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    materialId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    materialTag = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "_ShopifyMigration",
                columns: table => new
                {
                    TrackingId = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    Title = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: true),
                    Body = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    StyleTag = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    ColorTag = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    ImagePosition = table.Column<int>(type: "int", nullable: true),
                    ImageSrc = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    SizeDesc = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    internetprice = table.Column<decimal>(type: "money", nullable: true),
                    storeprice = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "_Temp_Deactivate_Fix",
                columns: table => new
                {
                    OldItemGroupId = table.Column<int>(type: "int", nullable: true),
                    NewItemGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "_WindowsServices_Error_Test",
                columns: table => new
                {
                    ErrorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Msg = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__WindowsServices_Error_Test", x => x.ErrorId);
                });

            migrationBuilder.CreateTable(
                name: "BAG_EventShop",
                columns: table => new
                {
                    eventShopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventId = table.Column<int>(type: "int", nullable: false),
                    ContactEmail = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    ContactPhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    ContactName = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    verificationCode = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: true),
                    City = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: true),
                    TimeOfDay = table.Column<int>(type: "int", nullable: true),
                    DayOfWeek = table.Column<int>(type: "int", nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAG_EventShop", x => x.eventShopId);
                });

            migrationBuilder.CreateTable(
                name: "BAG_RequestForm",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Comments = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    EstimatedGuest = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAG_RequestForm", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "BG_PhotoBlog",
                columns: table => new
                {
                    PhotoBlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    summary = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    addedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    addedBy = table.Column<int>(type: "int", nullable: true),
                    coverImageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BG_PhotoBlog", x => x.PhotoBlogId);
                });

            migrationBuilder.CreateTable(
                name: "BigCommerceCheckData",
                columns: table => new
                {
                    ShopSKU = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Manufacturer = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    SalePrice = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    googleid = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    trackingid = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    ProductUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BigComme__5D583E8839788055", x => x.ShopSKU);
                });

            migrationBuilder.CreateTable(
                name: "BW_Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    isfeatured = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    brandAlphabetCode = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    coverImageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BW_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "BW_Colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorDesc = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    IconClass = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BW_Colors", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "BW_Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    MaterialName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BW_Materials", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "CRM_ContactsNew",
                columns: table => new
                {
                    contactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GSM = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CountryCode = table.Column<int>(type: "int", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    LastContactDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isExistingCustomer = table.Column<bool>(type: "bit", nullable: true),
                    CustomerSince = table.Column<DateTime>(type: "datetime", nullable: true),
                    firstName = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_ContactsNew", x => x.contactId);
                });

            migrationBuilder.CreateTable(
                name: "CT_NewsFeed",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: true),
                    Details = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    ReferenceURL = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ByUserId = table.Column<int>(type: "int", nullable: true),
                    StatusCode = table.Column<int>(type: "int", nullable: true),
                    isFeatured = table.Column<int>(type: "int", nullable: true),
                    imageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    MobileImageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    categoryId = table.Column<int>(type: "int", nullable: true),
                    appId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_NewsFeed", x => x.NewsId);
                });

            migrationBuilder.CreateTable(
                name: "POS_Discount_UsageLog",
                columns: table => new
                {
                    DiscountAppliedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amountUsed = table.Column<decimal>(type: "money", nullable: false),
                    dateUsed = table.Column<DateTime>(type: "datetime", nullable: false),
                    refId = table.Column<int>(type: "int", nullable: false),
                    customerGSM = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    isCancelled = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POS_Discount_UsageLog", x => x.DiscountAppliedId);
                });

            migrationBuilder.CreateTable(
                name: "PriceCheckData",
                columns: table => new
                {
                    ShopSKU = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Manufacturer = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    SalePrice = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    googleid = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    trackingid = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    themeDesc = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ThemeId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    ThemeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    sizeDesc = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    colorId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    additionalimages = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PriceChe__5D583E8807E124C1", x => x.ShopSKU);
                });

            migrationBuilder.CreateTable(
                name: "TF_Affiliate_CommissionLog",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    AffiliateId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AdId = table.Column<int>(type: "int", nullable: true),
                    AffiliateReferralId = table.Column<int>(type: "int", nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    Commission = table.Column<decimal>(type: "money", nullable: true),
                    AdTypeId = table.Column<int>(type: "int", nullable: true),
                    ReceiptTotal = table.Column<decimal>(type: "money", nullable: true),
                    ReceiptId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Affiliate_CommissionLog", x => new { x.OrderId, x.AffiliateId });
                });

            migrationBuilder.CreateTable(
                name: "TF_AffiliateLink",
                columns: table => new
                {
                    adId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    destinationUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    affiliateId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    adName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    generatedCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_AffiliateLink", x => x.adId);
                });

            migrationBuilder.CreateTable(
                name: "TF_AffiliateNew",
                columns: table => new
                {
                    AffiliateId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    GSM = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true),
                    TotalDiscount = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    isSync = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    verificationcode = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    isVerified = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TF_Affil__0B4087CC0AD2A005", x => x.AffiliateId);
                });

            migrationBuilder.CreateTable(
                name: "TF_AffiliateRefferal",
                columns: table => new
                {
                    AffiliateRefferalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnonymousId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AffiliateId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DateVisited = table.Column<DateTime>(type: "datetime", nullable: false),
                    AddId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_AffiliateRefferal", x => x.AffiliateRefferalId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Affiliates",
                columns: table => new
                {
                    AffiliateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    GSM = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    ReferralId = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Affiliates", x => x.AffiliateId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Affiliates_Discount_Codes",
                columns: table => new
                {
                    AffiliateReferralId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffiliateId = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    DiscountCode = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    fname = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    gsm = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Affiliates_Discount_Codes", x => x.AffiliateReferralId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Affiliates_Reference",
                columns: table => new
                {
                    referenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sendToNumber = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true),
                    IPAddress = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    isSent = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Affiliates_Reference", x => x.referenceId);
                });

            migrationBuilder.CreateTable(
                name: "TF_BulkSMS_TransactionMessages",
                columns: table => new
                {
                    MsgId = table.Column<int>(type: "int", nullable: false),
                    transactionId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    isProcessed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_BulkSMS_TransactionMessages", x => new { x.MsgId, x.transactionId });
                });

            migrationBuilder.CreateTable(
                name: "TF_BulkSMSLog",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Message = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: true),
                    addedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    sentStatus = table.Column<int>(type: "int", nullable: true),
                    totalCount = table.Column<int>(type: "int", nullable: true),
                    msgType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_BulkSMSLog", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Card_Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    gateWayId = table.Column<int>(type: "int", nullable: false),
                    ResponseCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ResponseDescription = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: false),
                    IPAddress = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    tranxmsg = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Card_Transactions", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "TF_CheckinCheckout_Log",
                columns: table => new
                {
                    CheckId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    RefId = table.Column<int>(type: "int", nullable: true),
                    QtyModify = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: false),
                    Notes = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_CheckinCheckout_Log", x => x.CheckId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Collection_Deals",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    collectionId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DiscountTitle = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: true),
                    addedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPAddress = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    addedById = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    PriceGreaterThan = table.Column<decimal>(type: "money", nullable: true),
                    freeQuantity = table.Column<int>(type: "int", nullable: true),
                    PriceLessThan = table.Column<decimal>(type: "money", nullable: true),
                    freecollectionId = table.Column<int>(type: "int", nullable: true),
                    PercentageOff = table.Column<decimal>(type: "money", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    DiscountTypeId = table.Column<int>(type: "int", nullable: true),
                    longDiscountTitle = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    limitQty = table.Column<int>(type: "int", nullable: true),
                    isfeatured = table.Column<bool>(type: "bit", nullable: true),
                    freeCollectionId2 = table.Column<int>(type: "int", nullable: true),
                    imageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    MainImageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    SyncCode = table.Column<int>(type: "int", nullable: true),
                    batchId = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Collection_Deals", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Depth = table.Column<int>(type: "int", nullable: false),
                    Lft = table.Column<int>(type: "int", nullable: false),
                    Rgt = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    imageurl = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    position = table.Column<int>(type: "int", nullable: true),
                    Level1Parent = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isfeatured = table.Column<bool>(type: "bit", nullable: true),
                    GOOGLEID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    CODCode = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    WhatsAppCode = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Category", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Discount_Codes",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountCode = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    forUserGSM = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isSynced = table.Column<bool>(type: "bit", nullable: true),
                    codeValue = table.Column<decimal>(type: "money", nullable: true),
                    percentOff = table.Column<decimal>(type: "money", nullable: true),
                    numUsed = table.Column<int>(type: "int", nullable: true),
                    isSent = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Discount_Codes", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "TF_DiscountCode_DeActivateLog",
                columns: table => new
                {
                    DiscountCode = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: false),
                    IPAddress = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_DiscountCode_DeActivateLog", x => x.DiscountCode);
                });

            migrationBuilder.CreateTable(
                name: "TF_ExchangeRequest",
                columns: table => new
                {
                    exchangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerGSM = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    invoiceNumber = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    stateId = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    dateReceived = table.Column<DateTime>(type: "datetime", nullable: false),
                    dateRequested = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    reasonForExchange = table.Column<int>(type: "int", nullable: true),
                    pickupOption = table.Column<int>(type: "int", nullable: true),
                    returnModeId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_ExchangeRequest", x => x.exchangeId);
                });

            migrationBuilder.CreateTable(
                name: "TF_FrontPage_ImageRotator",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    imageTitle = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DestinationURL = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true),
                    Summary = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: true),
                    RotatorId = table.Column<int>(type: "int", nullable: true),
                    thumbNailUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_FrontPage_ImageRotator", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "TF_FrontPage_Widgets",
                columns: table => new
                {
                    WidgetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    CollectionId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    PageSize = table.Column<int>(type: "int", nullable: true),
                    CategoryPageSize = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    brandId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    colorId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_FrontPage_Widgets", x => x.WidgetId);
                });

            migrationBuilder.CreateTable(
                name: "TF_InternalSMS_Log",
                columns: table => new
                {
                    GSM = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    Message = table.Column<string>(type: "varchar(160)", unicode: false, maxLength: 160, nullable: true),
                    MsgType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TF_InvoicesLog",
                columns: table => new
                {
                    invoicesLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoicesItemId = table.Column<int>(type: "int", nullable: false),
                    SoldBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ChannelId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    TrackingId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    GSM = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InternetPrice = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    ContactId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    departmentId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    title = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    itemgroupid = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    locationId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    invoiceId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    invoicestatus = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_invoicesLog", x => x.invoicesLogId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Items_SearchHistory",
                columns: table => new
                {
                    SearchIndex = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchCriteria = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Items_SearchHistory", x => x.SearchIndex);
                });

            migrationBuilder.CreateTable(
                name: "TF_Items_ViewHistory",
                columns: table => new
                {
                    ViewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ViewDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumOfViews = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Items_ViewHistory", x => x.ViewId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Items_ViewHistory2",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ViewDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumOfViews = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TF_Items_Wishlist",
                columns: table => new
                {
                    WishListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Items__Wishlist", x => x.WishListId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Itemsgroup_DescriptionUpdated_Log",
                columns: table => new
                {
                    ItemgroupId = table.Column<int>(type: "int", nullable: false),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Itemsgroup_DescriptionUpdated_Log", x => x.ItemgroupId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Itemsgroup_DiscountedPrices",
                columns: table => new
                {
                    ItemGroupDiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemGroupId = table.Column<int>(type: "int", nullable: true),
                    DiscountedPrice = table.Column<decimal>(type: "money", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    byUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Itemsgroup_DiscountedPrices", x => x.ItemGroupDiscountId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Itemsgroup_RelatedDiscounts",
                columns: table => new
                {
                    ItemGroupRelatedDiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainItemGroupId = table.Column<int>(type: "int", nullable: false),
                    RelatedItemGroupId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: false),
                    ByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Itemsgroup_RelatedDiscounts", x => x.ItemGroupRelatedDiscountId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Itemsgroup_SizeLink",
                columns: table => new
                {
                    ItemgroupId = table.Column<int>(type: "int", nullable: false),
                    SimilarId = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    SizeDesc = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Itemsgroup_SizeLink", x => x.ItemgroupId);
                });

            migrationBuilder.CreateTable(
                name: "TF_ItemsImages",
                columns: table => new
                {
                    ProductImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SquareImageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    RecImageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    addedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    addedByIP = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    mobileProductImageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    desktopProductImageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Items_Images", x => x.ProductImageId);
                });

            migrationBuilder.CreateTable(
                name: "TF_ItemsVideos",
                columns: table => new
                {
                    VideoId = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    addedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    addedByIP = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_ItemsVideos", x => x.VideoId);
                });

            migrationBuilder.CreateTable(
                name: "TF_MenuLinks",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortTitle = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    destinationUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: true),
                    departmentId = table.Column<int>(type: "int", nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_MenuLinks", x => x.LinkId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Newsletter_Subscribers",
                columns: table => new
                {
                    subscriberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    firstName = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    NewsletterType = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<int>(type: "int", nullable: true),
                    validationCode = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    addedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ipaddress = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Newsletter_Subscribers", x => x.subscriberId);
                });

            migrationBuilder.CreateTable(
                name: "TF_OnlineInvoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerGSM = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    AlternativeGSM = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    CustomerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CustomerAddress = table.Column<string>(type: "varchar(350)", unicode: false, maxLength: 350, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    TrackingIds = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    DownloadCode = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    DownloadStatus = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    OrderIds = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    city = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    source = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    shipAfterDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    notes = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    invoiceTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_OnlineInvoices", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Order_Product",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AddedByUserId = table.Column<int>(type: "int", nullable: false),
                    ShippingCharges = table.Column<decimal>(type: "money", nullable: true),
                    HandlingCharges = table.Column<decimal>(type: "money", nullable: true),
                    NumOfItems = table.Column<int>(type: "int", nullable: false),
                    ShippingMode = table.Column<int>(type: "int", nullable: true),
                    ShipToId = table.Column<int>(type: "int", nullable: true),
                    IPAddress = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NumOfDeliveries = table.Column<int>(type: "int", nullable: true),
                    OrderAmount = table.Column<decimal>(type: "money", nullable: true),
                    discount = table.Column<decimal>(type: "money", nullable: true),
                    addedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SyncStatus = table.Column<int>(type: "int", nullable: true),
                    discountCode = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    expirydate = table.Column<DateTime>(type: "datetime", nullable: true),
                    statusCode = table.Column<int>(type: "int", nullable: true),
                    sourceId = table.Column<int>(type: "int", nullable: true),
                    lastUserId = table.Column<int>(type: "int", nullable: true),
                    affiliateId = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    affiliateReferralId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Order_Product", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Order_Product_Logger",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OrderType = table.Column<int>(type: "int", nullable: true),
                    ExpressCode = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    CurrentStatus = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    DeviceSource = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PaymentMode = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "money", nullable: true),
                    PaymentIPAddress = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    isActivated = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    downloadSyncStatus = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    TellerId = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    TellerNumber = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    customerGSM = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true),
                    cityId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    codeconfirmed = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    CheckoutDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    onlineNotes = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    stateId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    receiptViews = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Order_Product_Logger", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Order_Report",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ReportDetails = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    byUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Order_Report", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Order_VisaUrl",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false),
                    transactionId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    tellerId = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    tellerNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    url = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    xml = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Order_VisaUrl", x => new { x.orderId, x.transactionId });
                });

            migrationBuilder.CreateTable(
                name: "TF_ParameterItems",
                columns: table => new
                {
                    ParamId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_ProductParameters", x => new { x.ParamId, x.ProductId });
                });

            migrationBuilder.CreateTable(
                name: "TF_Parameters",
                columns: table => new
                {
                    ParamId = table.Column<int>(type: "int", nullable: false),
                    ParamName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    paramTypeId = table.Column<int>(type: "int", nullable: true),
                    addedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPAddress = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    departmentId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Parameters", x => x.ParamId);
                });

            migrationBuilder.CreateTable(
                name: "TF_ParameterTypes",
                columns: table => new
                {
                    ParamTypeId = table.Column<int>(type: "int", nullable: false),
                    ParamTypeName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    departmentId = table.Column<int>(type: "int", nullable: true),
                    addedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPaddress = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_ParameterTypes", x => x.ParamTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TF_ProductAttributes_List",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    AttrDesc = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_ProductAttributes_List", x => x.AttributeId);
                });

            migrationBuilder.CreateTable(
                name: "TF_ProductOrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductTitle = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: true),
                    ProductType = table.Column<int>(type: "int", nullable: true),
                    transactionId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RefId = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    flagId = table.Column<int>(type: "int", nullable: true),
                    saleId = table.Column<int>(type: "int", nullable: true),
                    freeCollectionId = table.Column<int>(type: "int", nullable: true),
                    expirydate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OfferPrice = table.Column<decimal>(type: "money", nullable: true),
                    ItemGroupSizeId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_ProductOrderItems", x => x.OrderItemId);
                });

            migrationBuilder.CreateTable(
                name: "TF_RelatedCollections",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    relatedCollectionId = table.Column<int>(type: "int", nullable: false),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_RelatedCollections", x => new { x.CollectionId, x.relatedCollectionId });
                });

            migrationBuilder.CreateTable(
                name: "TF_RelatedDepartments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    relatedDepartmentId = table.Column<int>(type: "int", nullable: false),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_RelatedDepartments", x => new { x.DepartmentId, x.relatedDepartmentId });
                });

            migrationBuilder.CreateTable(
                name: "TF_RelatedProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    RelatedProductId = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_RelatedProducts", x => new { x.ProductId, x.RelatedProductId });
                });

            migrationBuilder.CreateTable(
                name: "TF_SaleEvent_Items",
                columns: table => new
                {
                    SaleEventId = table.Column<int>(type: "int", nullable: false),
                    ItemGroupId = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((100))"),
                    OfferPrice = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_SaleEvent_Items", x => new { x.SaleEventId, x.ItemGroupId });
                });

            migrationBuilder.CreateTable(
                name: "TF_SaleEvents",
                columns: table => new
                {
                    SaleEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleEventName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SaleEventDesc = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_SaleEvents", x => x.SaleEventId);
                });

            migrationBuilder.CreateTable(
                name: "TF_SalesLog",
                columns: table => new
                {
                    SalesLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptItemId = table.Column<int>(type: "int", nullable: false),
                    SoldBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ChannelId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    TrackingId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    GSM = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    purchaseDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CashBackValue = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    PurchasePrice = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    ContactId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    cashBackProcessed = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    CollectionId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    departmentId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    collectionName = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    title = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    itemgroupid = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_SalesLog", x => x.SalesLogId);
                });

            migrationBuilder.CreateTable(
                name: "TF_SalesReceipt_Log",
                columns: table => new
                {
                    receiptId = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    ReceiptTotal = table.Column<decimal>(type: "money", nullable: true),
                    deliveryCharges = table.Column<decimal>(type: "money", nullable: true),
                    handlingCharges = table.Column<decimal>(type: "money", nullable: true),
                    discount = table.Column<decimal>(type: "money", nullable: true),
                    discountCode = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReceiptStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_SalesReceipt_Log", x => x.receiptId);
                });

            migrationBuilder.CreateTable(
                name: "TF_ShipToAddress",
                columns: table => new
                {
                    ShipToId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DeliverTo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NearestBusStop = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    NearestLandMark = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    DaytimePhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    PreferredDeliveryTime = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Country = table.Column<int>(type: "int", nullable: true),
                    OfficeResidential = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderGSM = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    OrderName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    hearaboutus = table.Column<int>(type: "int", nullable: true),
                    AlternativeGSM = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_ShipToAddress", x => x.ShipToId);
                });

            migrationBuilder.CreateTable(
                name: "TF_ShipToNewAddress",
                columns: table => new
                {
                    addressId = table.Column<int>(type: "int", nullable: false),
                    DeliverTo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NearestBusStop = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    NearestLandMark = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    DaytimePhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    PreferredDeliveryTime = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Country = table.Column<int>(type: "int", nullable: true),
                    OfficeResidential = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    alternativePhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_ShipToNewAddress", x => x.addressId);
                });

            migrationBuilder.CreateTable(
                name: "TF_SideImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageId = table.Column<int>(type: "int", nullable: true),
                    imageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    DestinationUrl = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    ImageTitle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_SideImages", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "TF_States_DeliveryCharges",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false),
                    StateDesc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DeliveryCharges = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_States_DeliveryCharges", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Subscribers",
                columns: table => new
                {
                    SubscriberId = table.Column<int>(type: "int", nullable: false),
                    subscriber = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    GSM = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Country = table.Column<int>(type: "int", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: true),
                    addedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IPAddress = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    emailVerified = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    emailCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    hasPaidSubscription = table.Column<bool>(type: "bit", nullable: true),
                    PhoneDeviceId = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    LastPasswordRequestDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Location = table.Column<int>(type: "int", nullable: true),
                    Area = table.Column<int>(type: "int", nullable: true),
                    Profession = table.Column<int>(type: "int", nullable: true),
                    Education = table.Column<int>(type: "int", nullable: true),
                    creditBalance = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TF_Subscribers_Preset",
                columns: table => new
                {
                    GSM = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    Country = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    area = table.Column<int>(type: "int", nullable: false),
                    addedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IPAddress = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    onlineCode = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    mobileCode = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    numSent = table.Column<int>(type: "int", nullable: true),
                    isVerified = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Subscribers_Preset", x => x.GSM);
                });

            migrationBuilder.CreateTable(
                name: "TF_Theme_Items",
                columns: table => new
                {
                    ThemeId = table.Column<int>(type: "int", nullable: false),
                    ItemGroupId = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((100))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Theme_Items", x => new { x.ThemeId, x.ItemGroupId });
                });

            migrationBuilder.CreateTable(
                name: "TF_ThemeGroups",
                columns: table => new
                {
                    ThemeGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThemeGroupName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_ThemeGroups", x => x.ThemeGroupId);
                });

            migrationBuilder.CreateTable(
                name: "TF_Themes",
                columns: table => new
                {
                    ThemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThemeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ThemeDesc = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    ThemeGroupId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Themes", x => x.ThemeId);
                });

            migrationBuilder.CreateTable(
                name: "TF_UnregisteredPublisher",
                columns: table => new
                {
                    PubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Category = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isFeatured = table.Column<bool>(type: "bit", nullable: true),
                    imageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    profile = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_UnregisteredPublisher", x => x.PubId);
                });

            migrationBuilder.CreateTable(
                name: "TF_User_Keyword",
                columns: table => new
                {
                    GSM = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: false),
                    Keyword = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    addedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_User_Keyword", x => x.GSM);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    userName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    sex = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Location = table.Column<int>(type: "int", nullable: true),
                    GSM = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "webpages_Membership",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ConfirmationToken = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    LastPasswordFailureDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PasswordFailuresSinceLastSuccess = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PasswordChangedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PasswordVerificationToken = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PasswordVerificationTokenExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__webpages__1788CC4C6383C8BA", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "webpages_OAuthMembership",
                columns: table => new
                {
                    Provider = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProviderUserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__webpages__F53FC0ED6754599E", x => new { x.Provider, x.ProviderUserId });
                });

            migrationBuilder.CreateTable(
                name: "webpages_Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__webpages__8AFACE1A6B24EA82", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "webpages_UsersInRoles",
                columns: table => new
                {
                    RoleUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_webpages_UsersInRoles", x => x.RoleUserId);
                });

            migrationBuilder.CreateTable(
                name: "BG_PhotoBlog_Items",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoBlogId = table.Column<int>(type: "int", nullable: true),
                    imageurl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Imagetitle = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BG_PhotoBlog_Items", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_BG_PhotoBlog_Items_BG_PhotoBlog",
                        column: x => x.PhotoBlogId,
                        principalTable: "BG_PhotoBlog",
                        principalColumn: "PhotoBlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TF_ItemsGroup",
                columns: table => new
                {
                    ItemGroupId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: true),
                    searchTags = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    NumOfViews = table.Column<int>(type: "int", nullable: true),
                    SquareImageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    HighResolutionUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    CollectionId = table.Column<int>(type: "int", nullable: true),
                    vendorprice = table.Column<decimal>(type: "money", nullable: true),
                    storeprice = table.Column<decimal>(type: "money", nullable: true),
                    limitprice = table.Column<decimal>(type: "money", nullable: true),
                    internetprice = table.Column<decimal>(type: "money", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: true),
                    location = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    producttype = table.Column<int>(type: "int", nullable: true),
                    startPrice = table.Column<decimal>(type: "money", nullable: true),
                    isfeatured = table.Column<bool>(type: "bit", nullable: true),
                    posref = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: true),
                    QualityCrit = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    YouTubeId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    isHot = table.Column<bool>(type: "bit", nullable: true),
                    brandId = table.Column<int>(type: "int", nullable: true),
                    offerPrice = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
                    BazaarPrice = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
                    MobileImageUrl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    colorId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    similarId = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    numAvailable = table.Column<int>(type: "int", nullable: true),
                    trackingId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    details = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    materialId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    PositionId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((500))"),
                    frontPagePositionId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((500))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroup", x => x.ItemGroupId);
                    table.ForeignKey(
                        name: "FK_TF_ItemsGroup_TF_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TF_Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TF_States_Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CODAvailable = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    DeliveryCharges = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_States_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_TF_States_Cities_TF_States_DeliveryCharges",
                        column: x => x.StateId,
                        principalTable: "TF_States_DeliveryCharges",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TF_Itemsgroup_Sizes",
                columns: table => new
                {
                    ItemGroupSizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemGroupId = table.Column<int>(type: "int", nullable: false),
                    SizeDesc = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    TrackingId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    SizeCode = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TF_Itemsgroup_Sizes", x => x.ItemGroupSizeId);
                    table.ForeignKey(
                        name: "FK_TF_Itemsgroup_Sizes_TF_ItemsGroup",
                        column: x => x.ItemGroupId,
                        principalTable: "TF_ItemsGroup",
                        principalColumn: "ItemGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BG_PhotoBlog_Items_PhotoBlogId",
                table: "BG_PhotoBlog_Items",
                column: "PhotoBlogId");

            migrationBuilder.CreateIndex(
                name: "NCI_ItemgroupId_PositionId",
                table: "TF_ItemsGroup",
                columns: new[] { "ItemGroupId", "PositionId" },
                unique: true,
                filter: "[PositionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "pk_itemsgroup_param",
                table: "TF_ItemsGroup",
                columns: new[] { "isactive", "numAvailable" });

            migrationBuilder.CreateIndex(
                name: "tf_items_group_isactive",
                table: "TF_ItemsGroup",
                columns: new[] { "isactive", "numAvailable" });

            migrationBuilder.CreateIndex(
                name: "Tf_itemsgroup_BySearch",
                table: "TF_ItemsGroup",
                columns: new[] { "DepartmentId", "isactive", "numAvailable" });

            migrationBuilder.CreateIndex(
                name: "tf_itemsgroup_getactive",
                table: "TF_ItemsGroup",
                columns: new[] { "isactive", "colorId", "numAvailable" });

            migrationBuilder.CreateIndex(
                name: "IX_TF_Itemsgroup_Sizes_ItemGroupId",
                table: "TF_Itemsgroup_Sizes",
                column: "ItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TF_States_Cities_StateId",
                table: "TF_States_Cities",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_BigCommerceMigration");

            migrationBuilder.DropTable(
                name: "_ShopifyMigration");

            migrationBuilder.DropTable(
                name: "_Temp_Deactivate_Fix");

            migrationBuilder.DropTable(
                name: "_WindowsServices_Error_Test");

            migrationBuilder.DropTable(
                name: "BAG_EventShop");

            migrationBuilder.DropTable(
                name: "BAG_RequestForm");

            migrationBuilder.DropTable(
                name: "BG_PhotoBlog_Items");

            migrationBuilder.DropTable(
                name: "BigCommerceCheckData");

            migrationBuilder.DropTable(
                name: "BW_Brands");

            migrationBuilder.DropTable(
                name: "BW_Colors");

            migrationBuilder.DropTable(
                name: "BW_Materials");

            migrationBuilder.DropTable(
                name: "CRM_ContactsNew");

            migrationBuilder.DropTable(
                name: "CT_NewsFeed");

            migrationBuilder.DropTable(
                name: "POS_Discount_UsageLog");

            migrationBuilder.DropTable(
                name: "PriceCheckData");

            migrationBuilder.DropTable(
                name: "TF_Affiliate_CommissionLog");

            migrationBuilder.DropTable(
                name: "TF_AffiliateLink");

            migrationBuilder.DropTable(
                name: "TF_AffiliateNew");

            migrationBuilder.DropTable(
                name: "TF_AffiliateRefferal");

            migrationBuilder.DropTable(
                name: "TF_Affiliates");

            migrationBuilder.DropTable(
                name: "TF_Affiliates_Discount_Codes");

            migrationBuilder.DropTable(
                name: "TF_Affiliates_Reference");

            migrationBuilder.DropTable(
                name: "TF_BulkSMS_TransactionMessages");

            migrationBuilder.DropTable(
                name: "TF_BulkSMSLog");

            migrationBuilder.DropTable(
                name: "TF_Card_Transactions");

            migrationBuilder.DropTable(
                name: "TF_CheckinCheckout_Log");

            migrationBuilder.DropTable(
                name: "TF_Collection_Deals");

            migrationBuilder.DropTable(
                name: "TF_Discount_Codes");

            migrationBuilder.DropTable(
                name: "TF_DiscountCode_DeActivateLog");

            migrationBuilder.DropTable(
                name: "TF_ExchangeRequest");

            migrationBuilder.DropTable(
                name: "TF_FrontPage_ImageRotator");

            migrationBuilder.DropTable(
                name: "TF_FrontPage_Widgets");

            migrationBuilder.DropTable(
                name: "TF_InternalSMS_Log");

            migrationBuilder.DropTable(
                name: "TF_InvoicesLog");

            migrationBuilder.DropTable(
                name: "TF_Items_SearchHistory");

            migrationBuilder.DropTable(
                name: "TF_Items_ViewHistory");

            migrationBuilder.DropTable(
                name: "TF_Items_ViewHistory2");

            migrationBuilder.DropTable(
                name: "TF_Items_Wishlist");

            migrationBuilder.DropTable(
                name: "TF_Itemsgroup_DescriptionUpdated_Log");

            migrationBuilder.DropTable(
                name: "TF_Itemsgroup_DiscountedPrices");

            migrationBuilder.DropTable(
                name: "TF_Itemsgroup_RelatedDiscounts");

            migrationBuilder.DropTable(
                name: "TF_Itemsgroup_SizeLink");

            migrationBuilder.DropTable(
                name: "TF_Itemsgroup_Sizes");

            migrationBuilder.DropTable(
                name: "TF_ItemsImages");

            migrationBuilder.DropTable(
                name: "TF_ItemsVideos");

            migrationBuilder.DropTable(
                name: "TF_MenuLinks");

            migrationBuilder.DropTable(
                name: "TF_Newsletter_Subscribers");

            migrationBuilder.DropTable(
                name: "TF_OnlineInvoices");

            migrationBuilder.DropTable(
                name: "TF_Order_Product");

            migrationBuilder.DropTable(
                name: "TF_Order_Product_Logger");

            migrationBuilder.DropTable(
                name: "TF_Order_Report");

            migrationBuilder.DropTable(
                name: "TF_Order_VisaUrl");

            migrationBuilder.DropTable(
                name: "TF_ParameterItems");

            migrationBuilder.DropTable(
                name: "TF_Parameters");

            migrationBuilder.DropTable(
                name: "TF_ParameterTypes");

            migrationBuilder.DropTable(
                name: "TF_ProductAttributes_List");

            migrationBuilder.DropTable(
                name: "TF_ProductOrderItems");

            migrationBuilder.DropTable(
                name: "TF_RelatedCollections");

            migrationBuilder.DropTable(
                name: "TF_RelatedDepartments");

            migrationBuilder.DropTable(
                name: "TF_RelatedProducts");

            migrationBuilder.DropTable(
                name: "TF_SaleEvent_Items");

            migrationBuilder.DropTable(
                name: "TF_SaleEvents");

            migrationBuilder.DropTable(
                name: "TF_SalesLog");

            migrationBuilder.DropTable(
                name: "TF_SalesReceipt_Log");

            migrationBuilder.DropTable(
                name: "TF_ShipToAddress");

            migrationBuilder.DropTable(
                name: "TF_ShipToNewAddress");

            migrationBuilder.DropTable(
                name: "TF_SideImages");

            migrationBuilder.DropTable(
                name: "TF_States_Cities");

            migrationBuilder.DropTable(
                name: "TF_Subscribers");

            migrationBuilder.DropTable(
                name: "TF_Subscribers_Preset");

            migrationBuilder.DropTable(
                name: "TF_Theme_Items");

            migrationBuilder.DropTable(
                name: "TF_ThemeGroups");

            migrationBuilder.DropTable(
                name: "TF_Themes");

            migrationBuilder.DropTable(
                name: "TF_UnregisteredPublisher");

            migrationBuilder.DropTable(
                name: "TF_User_Keyword");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "webpages_Membership");

            migrationBuilder.DropTable(
                name: "webpages_OAuthMembership");

            migrationBuilder.DropTable(
                name: "webpages_Roles");

            migrationBuilder.DropTable(
                name: "webpages_UsersInRoles");

            migrationBuilder.DropTable(
                name: "BG_PhotoBlog");

            migrationBuilder.DropTable(
                name: "TF_ItemsGroup");

            migrationBuilder.DropTable(
                name: "TF_States_DeliveryCharges");

            migrationBuilder.DropTable(
                name: "TF_Department");
        }
    }
}
