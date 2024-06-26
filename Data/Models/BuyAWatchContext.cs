using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Kubona.Data.Models
{
    public partial class BuyAWatchContext : DbContext
    {
        public BuyAWatchContext()
        {
        }

        public BuyAWatchContext(DbContextOptions<BuyAWatchContext> options)
            : base(options)
        {
        }

        public string TF_ItemsGroup_GetAvailableSizes(int itemGroupId)
            => throw new NotSupportedException();

        public Boolean TF_ItemsGroup_IsSizeAvailable(int itemGroupId, int? sizeId)
           => throw new NotSupportedException();

        public string TF_Items_GetSiteMap(int productId)
            => throw new NotSupportedException();

        public decimal TF_ItemsGroup_GetSalePrice(int itemGroupId)
            => throw new NotSupportedException();

        public string TF_Items_GetThemeDesc(int productId)
            => throw new NotSupportedException();

        public string TF_Items_GetThemeName(int productId)
            => throw new NotSupportedException();

        public string TF_ItemsGroup_GetAvailableSizesString(int productId)
            => throw new NotSupportedException();

        public string TF_ItemsGroup_GetAdditionalImagesString(int productId)
            => throw new NotSupportedException();


        public virtual DbSet<BagEventShop> BagEventShops { get; set; }
        public virtual DbSet<BagRequestForm> BagRequestForms { get; set; }
        public virtual DbSet<BgPhotoBlog> BgPhotoBlogs { get; set; }
        public virtual DbSet<BgPhotoBlogItem> BgPhotoBlogItems { get; set; }
        public virtual DbSet<BigCommerceCheckDatum> BigCommerceCheckData { get; set; }
        public virtual DbSet<BigCommerceMigration> BigCommerceMigrations { get; set; }
        public virtual DbSet<BwBrand> BwBrands { get; set; }
        public virtual DbSet<BwColor> BwColors { get; set; }
        public virtual DbSet<BwMaterial> BwMaterials { get; set; }
        public virtual DbSet<CrmContactsNew> CrmContactsNews { get; set; }
        public virtual DbSet<CrmCurationKey> CrmCurationKeys { get; set; }
        public virtual DbSet<CtNewsFeed> CtNewsFeeds { get; set; }
        public virtual DbSet<PosDiscountUsageLog> PosDiscountUsageLogs { get; set; }
        public virtual DbSet<PriceCheckDatum> PriceCheckData { get; set; }
        public virtual DbSet<ShopifyMigration> ShopifyMigrations { get; set; }
        public virtual DbSet<TempDeactivateFix> TempDeactivateFixes { get; set; }
        public virtual DbSet<TfAffiliate> TfAffiliates { get; set; }
        public virtual DbSet<TfAffiliateCommissionLog> TfAffiliateCommissionLogs { get; set; }
        public virtual DbSet<TfAffiliateLink> TfAffiliateLinks { get; set; }
        public virtual DbSet<TfAffiliateNew> TfAffiliateNews { get; set; }
        public virtual DbSet<TfAffiliateRefferal> TfAffiliateRefferals { get; set; }
        public virtual DbSet<TfAffiliatesDiscountCode> TfAffiliatesDiscountCodes { get; set; }
        public virtual DbSet<TfAffiliatesReference> TfAffiliatesReferences { get; set; }
        public virtual DbSet<TfBulkSmsTransactionMessage> TfBulkSmsTransactionMessages { get; set; }
        public virtual DbSet<TfBulkSmslog> TfBulkSmslogs { get; set; }
        public virtual DbSet<TfCardTransaction> TfCardTransactions { get; set; }
        public virtual DbSet<TfCheckinCheckoutLog> TfCheckinCheckoutLogs { get; set; }
        public virtual DbSet<TfCollectionDeal> TfCollectionDeals { get; set; }
        public virtual DbSet<TfDepartment> TfDepartments { get; set; }
        public virtual DbSet<TfDiscountCode> TfDiscountCodes { get; set; }
        public virtual DbSet<TfDiscountCodeDeActivateLog> TfDiscountCodeDeActivateLogs { get; set; }
        public virtual DbSet<TfExchangeRequest> TfExchangeRequests { get; set; }
        public virtual DbSet<TfFrontPageImageRotator> TfFrontPageImageRotators { get; set; }
        public virtual DbSet<TfFrontPageWidget> TfFrontPageWidgets { get; set; }
        public virtual DbSet<TfInternalSmsLog> TfInternalSmsLogs { get; set; }
        public virtual DbSet<TfInvoicesLog> TfInvoicesLogs { get; set; }
        public virtual DbSet<TfItemsGroup> TfItemsGroups { get; set; }
        public virtual DbSet<TfItemsgroupViewHistory> TFItemsGroupViewHistories { get; set; }
        public virtual DbSet<TfItemsImage> TfItemsImages { get; set; }
        public virtual DbSet<TfItemsSearchHistory> TfItemsSearchHistories { get; set; }
        public virtual DbSet<TfItemsVideo> TfItemsVideos { get; set; }
        public virtual DbSet<TfItemsViewHistory> TfItemsViewHistories { get; set; }
        public virtual DbSet<TfItemsViewHistory2> TfItemsViewHistory2s { get; set; }
        public virtual DbSet<TfItemsWishlist> TfItemsWishlists { get; set; }
        public virtual DbSet<TfItemsgroupDescriptionUpdatedLog> TfItemsgroupDescriptionUpdatedLogs { get; set; }
        public virtual DbSet<TfItemsgroupDiscountedPrice> TfItemsgroupDiscountedPrices { get; set; }
        public virtual DbSet<TfItemsgroupRelatedDiscount> TfItemsgroupRelatedDiscounts { get; set; }
        public virtual DbSet<TfItemsgroupSize> TfItemsgroupSizes { get; set; }
        public virtual DbSet<TfItemsgroupSizeLink> TfItemsgroupSizeLinks { get; set; }
        public virtual DbSet<TfMenuLink> TfMenuLinks { get; set; }
        public virtual DbSet<TfNewsletterSubscriber> TfNewsletterSubscribers { get; set; }
        public virtual DbSet<TFNewCustOrderVerify> TFNewCustOrderVerifies { get; set; }
        public virtual DbSet<TfOnlineInvoice> TfOnlineInvoices { get; set; }
        public virtual DbSet<TfOrderPaymentOptions> TfOrderPaymentOptions { get; set; }
        public virtual DbSet<TfOrderProduct> TfOrderProducts { get; set; }
        public virtual DbSet<TfOrderProductLogger> TfOrderProductLoggers { get; set; }
        public virtual DbSet<TfOrderReport> TfOrderReports { get; set; }
        public virtual DbSet<TfOrderVisaUrl> TfOrderVisaUrls { get; set; }
        public virtual DbSet<TfParameter> TfParameters { get; set; }
        public virtual DbSet<TfParameterItem> TfParameterItems { get; set; }
        public virtual DbSet<TfParameterType> TfParameterTypes { get; set; }
        public virtual DbSet<TfProductAttributesList> TfProductAttributesLists { get; set; }
        public virtual DbSet<TfProductOrderItem> TfProductOrderItems { get; set; }
        public virtual DbSet<TfRelatedCollection> TfRelatedCollections { get; set; }
        public virtual DbSet<TfRelatedDepartment> TfRelatedDepartments { get; set; }
        public virtual DbSet<TfRelatedProduct> TfRelatedProducts { get; set; }
        public virtual DbSet<TfSaleEvent> TfSaleEvents { get; set; }
        public virtual DbSet<TfSaleEventItem> TfSaleEventItems { get; set; }
        public virtual DbSet<TfSalesLog> TfSalesLogs { get; set; }
        public virtual DbSet<TfSalesReceiptLog> TfSalesReceiptLogs { get; set; }
        public virtual DbSet<TfShipToAddress> TfShipToAddresses { get; set; }
        public virtual DbSet<TfShipToNewAddress> TfShipToNewAddresses { get; set; }
        public virtual DbSet<TfSideImage> TfSideImages { get; set; }
        public virtual DbSet<TfSize> TfSizes { get; set; }
        public virtual DbSet<TfHeelHeight> TfHeelHeights { get; set; }
        public virtual DbSet<TfSimilar> TfSimilars { get; set; }
        public virtual DbSet<TfStatesCity> TfStatesCities { get; set; }
        public virtual DbSet<TfStatesDeliveryCharge> TfStatesDeliveryCharges { get; set; }
        public virtual DbSet<TfSubDepartment> TfSubDepartments { get; set; }
        public virtual DbSet<TfSubscriber> TfSubscribers { get; set; }
        public virtual DbSet<TfSubscribersPreset> TfSubscribersPresets { get; set; }
        public virtual DbSet<TfTheme> TfThemes { get; set; }
        public virtual DbSet<TfThemeGroup> TfThemeGroups { get; set; }
        public virtual DbSet<TfThemeItem> TfThemeItems { get; set; }
        public virtual DbSet<TfUnregisteredPublisher> TfUnregisteredPublishers { get; set; }
        public virtual DbSet<TfUserKeyword> TfUserKeywords { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<WebpagesMembership> WebpagesMemberships { get; set; }
        public virtual DbSet<WebpagesOauthMembership> WebpagesOauthMemberships { get; set; }
        public virtual DbSet<WebpagesRole> WebpagesRoles { get; set; }
        public virtual DbSet<WebpagesUsersInRole> WebpagesUsersInRoles { get; set; }
        public virtual DbSet<WindowsServicesErrorTest> WindowsServicesErrorTests { get; set; }
        public virtual DbSet<TfWhatsAppVerify> TfWhatsAppVerifies { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.;Database=BuyAWatch;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.HasDbFunction(typeof(BuyAWatchContext).GetMethod(nameof(TF_ItemsGroup_GetAvailableSizes), new[] { typeof(int) }));
           
            modelBuilder.HasDbFunction(typeof(BuyAWatchContext).GetMethod(nameof(TF_ItemsGroup_IsSizeAvailable), new[] { typeof(int), typeof(int) }));

            modelBuilder.Entity<BagEventShop>(entity =>
            {
                entity.Property(e => e.ContactEmail).IsUnicode(false);

                entity.Property(e => e.ContactName).IsUnicode(false);

                entity.Property(e => e.ContactPhone).IsUnicode(false);

                entity.Property(e => e.VerificationCode).IsUnicode(false);
            });

            modelBuilder.Entity<BagRequestForm>(entity =>
            {
                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.EstimatedGuest).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);
            });

            modelBuilder.Entity<BgPhotoBlog>(entity =>
            {
                entity.Property(e => e.CoverImageUrl).IsUnicode(false);

                entity.Property(e => e.Summary).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<BgPhotoBlogItem>(entity =>
            {
                entity.Property(e => e.Imagetitle).IsUnicode(false);

                entity.Property(e => e.Imageurl).IsUnicode(false);

                entity.HasOne(d => d.PhotoBlog)
                    .WithMany(p => p.BgPhotoBlogItems)
                    .HasForeignKey(d => d.PhotoBlogId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BG_PhotoBlog_Items_BG_PhotoBlog");
            });

            modelBuilder.Entity<BigCommerceCheckDatum>(entity =>
            {
                entity.HasKey(e => e.ShopSku)
                    .HasName("PK__BigComme__5D583E8839788055");

                entity.Property(e => e.ShopSku).ValueGeneratedNever();

                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Googleid).HasDefaultValueSql("((0))");

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.Manufacturer).IsUnicode(false);

                entity.Property(e => e.ProductUrl).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.Trackingid).IsUnicode(false);
            });

            modelBuilder.Entity<BigCommerceMigration>(entity =>
            {
                entity.Property(e => e.Body).IsUnicode(false);

                entity.Property(e => e.ColorTag).IsUnicode(false);

                entity.Property(e => e.Counter).HasDefaultValueSql("((0))");

                entity.Property(e => e.Image1Src).IsUnicode(false);

                entity.Property(e => e.Image2Src).IsUnicode(false);

                entity.Property(e => e.Image3Src).IsUnicode(false);

                entity.Property(e => e.Image4Src).IsUnicode(false);

                entity.Property(e => e.Image5Src).IsUnicode(false);

                entity.Property(e => e.Image6Src).IsUnicode(false);

                entity.Property(e => e.Image7Src).IsUnicode(false);

                entity.Property(e => e.Image8Src).IsUnicode(false);

                entity.Property(e => e.ImageSrc).IsUnicode(false);

                entity.Property(e => e.MaterialId).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaterialTag).IsUnicode(false);

                entity.Property(e => e.SizeDesc).IsUnicode(false);

                entity.Property(e => e.StyleTag).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.TrackingId).IsUnicode(false);

                entity.Property(e => e.VTrackingid).IsUnicode(false);
            });

            modelBuilder.Entity<BwBrand>(entity =>
            {
                entity.Property(e => e.BrandAlphabetCode).HasDefaultValueSql("((0))");

                entity.Property(e => e.BrandName).IsUnicode(false);

                entity.Property(e => e.CoverImageUrl).IsUnicode(false);

                entity.Property(e => e.Isfeatured).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<BwColor>(entity =>
            {
                entity.Property(e => e.ColorDesc).IsUnicode(false);

                entity.Property(e => e.IconClass).IsUnicode(false);
            });

            modelBuilder.Entity<BwMaterial>(entity =>
            {
                entity.Property(e => e.MaterialId).ValueGeneratedNever();

                entity.Property(e => e.MaterialName).IsUnicode(false);
            });

            modelBuilder.Entity<CrmContactsNew>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gsm).IsUnicode(false);
            });

            modelBuilder.Entity<CrmCurationKey>(entity =>
            {
                entity.HasKey(e => e.curationID)
                    .HasName("PK_CRM_CurationKey");
                entity.Property(e => e.byUserID).HasDefaultValueSql("((0))");
                entity.Property(e => e.numOfViews).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<CtNewsFeed>(entity =>
            {
                entity.Property(e => e.Details).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.MobileImageUrl).IsUnicode(false);

                entity.Property(e => e.ReferenceUrl).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<PosDiscountUsageLog>(entity =>
            {
                entity.Property(e => e.CustomerGsm).IsUnicode(false);

                entity.Property(e => e.IsCancelled).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PriceCheckDatum>(entity =>
            {
                entity.HasKey(e => e.ShopSku)
                    .HasName("PK__PriceChe__5D583E8807E124C1");

                entity.Property(e => e.ShopSku).ValueGeneratedNever();

                entity.Property(e => e.Additionalimages).IsUnicode(false);

                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.ColorId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Googleid).HasDefaultValueSql("((0))");

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.Manufacturer).IsUnicode(false);

                entity.Property(e => e.SizeDesc).IsUnicode(false);

                entity.Property(e => e.ThemeDesc).IsUnicode(false);

                entity.Property(e => e.ThemeId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ThemeName).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.Trackingid).IsUnicode(false);
            });

            modelBuilder.Entity<ShopifyMigration>(entity =>
            {
                entity.Property(e => e.Body).IsUnicode(false);

                entity.Property(e => e.ColorTag).IsUnicode(false);

                entity.Property(e => e.ImageSrc).IsUnicode(false);

                entity.Property(e => e.SizeDesc).IsUnicode(false);

                entity.Property(e => e.StyleTag).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.TrackingId).IsUnicode(false);
            });

            modelBuilder.Entity<TfAffiliate>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gsm).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.ReferralId).IsUnicode(false);
            });

            modelBuilder.Entity<TfAffiliateCommissionLog>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.AffiliateId });

                entity.Property(e => e.AffiliateId).IsUnicode(false);
            });

            modelBuilder.Entity<TfAffiliateLink>(entity =>
            {
                entity.Property(e => e.TypeId).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TfAffiliateNew>(entity =>
            {
                entity.HasKey(e => e.AffiliateId)
                    .HasName("PK__TF_Affil__0B4087CC0AD2A005");

                entity.Property(e => e.AffiliateId).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gsm).IsUnicode(false);

                entity.Property(e => e.IsSync).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsVerified).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.Property(e => e.Verificationcode).IsUnicode(false);
            });

            modelBuilder.Entity<TfAffiliatesDiscountCode>(entity =>
            {
                entity.Property(e => e.AffiliateId).IsUnicode(false);

                entity.Property(e => e.DiscountCode).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Fname).IsUnicode(false);

                entity.Property(e => e.Gsm).IsUnicode(false);
            });

            modelBuilder.Entity<TfAffiliatesReference>(entity =>
            {
                entity.Property(e => e.Ipaddress).IsUnicode(false);

                entity.Property(e => e.SendToNumber).IsUnicode(false);
            });

            modelBuilder.Entity<TfBulkSmsTransactionMessage>(entity =>
            {
                entity.HasKey(e => new { e.MsgId, e.TransactionId });

                entity.Property(e => e.TransactionId).IsUnicode(false);
            });

            modelBuilder.Entity<TfBulkSmslog>(entity =>
            {
                entity.Property(e => e.TransactionId).IsUnicode(false);

                entity.Property(e => e.Message).IsUnicode(false);
            });

            modelBuilder.Entity<TfCardTransaction>(entity =>
            {
                entity.Property(e => e.TransactionId).IsUnicode(false);

                entity.Property(e => e.Ipaddress).IsUnicode(false);

                entity.Property(e => e.ResponseCode).IsUnicode(false);

                entity.Property(e => e.ResponseDescription).IsUnicode(false);

                entity.Property(e => e.Tranxmsg).IsUnicode(false);
            });

            modelBuilder.Entity<TfCheckinCheckoutLog>(entity =>
            {
                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.TrackingId).IsUnicode(false);
            });

            modelBuilder.Entity<TfCollectionDeal>(entity =>
            {
                entity.Property(e => e.BatchId).IsUnicode(false);

                entity.Property(e => e.DiscountTitle).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.Ipaddress).IsUnicode(false);

                entity.Property(e => e.LongDiscountTitle).IsUnicode(false);

                entity.Property(e => e.MainImageUrl).IsUnicode(false);
            });

            modelBuilder.Entity<TfDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK_TF_Category");

                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.Property(e => e.Codcode).HasDefaultValueSql("((1))");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Googleid).HasDefaultValueSql("((0))");

                entity.Property(e => e.Imageurl).IsUnicode(false);

                entity.Property(e => e.WhatsAppCode).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TfDiscountCode>(entity =>
            {
                entity.Property(e => e.DiscountCode).IsUnicode(false);

                entity.Property(e => e.ForUserGsm).IsUnicode(false);
            });

            modelBuilder.Entity<TfDiscountCodeDeActivateLog>(entity =>
            {
                entity.Property(e => e.DiscountCode).IsUnicode(false);

                entity.Property(e => e.Ipaddress).IsUnicode(false);
            });

            modelBuilder.Entity<TfExchangeRequest>(entity =>
            {
                entity.Property(e => e.CustomerGsm).IsUnicode(false);

                entity.Property(e => e.InvoiceNumber).IsUnicode(false);

                entity.Property(e => e.ReturnModeId).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TfFrontPageImageRotator>(entity =>
            {
                entity.Property(e => e.DestinationUrl).IsUnicode(false);

                entity.Property(e => e.ImageTitle).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.Summary).IsUnicode(false);

                entity.Property(e => e.ThumbNailUrl).IsUnicode(false);
            });

            modelBuilder.Entity<TfFrontPageWidget>(entity =>
            {
                entity.Property(e => e.BrandId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ColorId).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TfInternalSmsLog>(entity =>
            {
                entity.Property(e => e.Gsm).IsUnicode(false);

                entity.Property(e => e.Message).IsUnicode(false);
            });

            modelBuilder.Entity<TfInvoicesLog>(entity =>
            {
                entity.HasKey(e => e.InvoicesLogId)
                    .HasName("PK_TF_invoicesLog");

                entity.Property(e => e.ChannelId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ContactId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DepartmentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Gsm).IsUnicode(false);

                entity.Property(e => e.InvoiceId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Invoicestatus).HasDefaultValueSql("((0))");

                entity.Property(e => e.Itemgroupid).HasDefaultValueSql("((0))");

                entity.Property(e => e.LocationId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.SoldBy).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.TrackingId).IsUnicode(false);
            });

            modelBuilder.Entity<TfItemsGroup>(entity =>
            {
                entity.HasKey(e => e.ItemGroupId)
                    .HasName("PK_ItemGroup");

                entity.Property(e => e.ItemGroupId).ValueGeneratedNever();

                entity.Property(e => e.BazaarPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.ColorId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Details).IsUnicode(false);

                entity.Property(e => e.ExpiryDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FrontPagePositionId).HasDefaultValueSql("((500))");

                entity.Property(e => e.HighResolutionUrl).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.MaterialId).HasDefaultValueSql("((0))");

                entity.Property(e => e.MobileImageUrl).IsUnicode(false);

                entity.Property(e => e.OfferPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.PositionId).HasDefaultValueSql("((500))");

                entity.Property(e => e.HeelHeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.StyleId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Posref).IsUnicode(false);

                entity.Property(e => e.QualityCrit).IsUnicode(false);

                entity.Property(e => e.SearchTags).IsUnicode(false);

                entity.Property(e => e.SimilarId).IsUnicode(false);

                entity.Property(e => e.SquareImageUrl).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.TrackingId).IsUnicode(false);

                entity.Property(e => e.YouTubeId).IsUnicode(false);

                entity.HasOne(d => d.TfDepartment)
                    .WithMany(p => p.TfItemsGroups)
                    .HasForeignKey(d => d.DepartmentId);

                entity.HasOne(d => d.BwColor)
                    .WithMany(p => p.TfItemsGroups)
                    .HasForeignKey(d => d.ColorId);

                entity.HasOne(d => d.BwBrand)
                    .WithMany(p => p.TfItemsGroups)
                    .HasForeignKey(d => d.BrandId);
                entity.HasOne(d=>d.TfHeelHeight)
                    .WithMany(p=>p.TfItemsGroups)
                    .HasForeignKey(d => d.HeelHeight);
                entity.HasOne(f => f.TfSubDepartment)
                   .WithMany(g => g.TfItemsGroups)
                   .HasForeignKey(h => h.StyleId);
            });

            modelBuilder.Entity<TfItemsImage>(entity =>
            {
                entity.HasKey(e => e.ProductImageId)
                    .HasName("PK_TF_Items_Images");

                entity.Property(e => e.AddedByIp).IsUnicode(false);

                entity.Property(e => e.DesktopProductImageUrl).IsUnicode(false);

                entity.Property(e => e.MobileProductImageUrl).IsUnicode(false);

                entity.Property(e => e.RecImageUrl).IsUnicode(false);

                entity.Property(e => e.SquareImageUrl).IsUnicode(false);

                entity.HasOne(d => d.ItemGroup)
                  .WithMany(p => p.TfItemsgroupImages)
                  .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<TfItemsSearchHistory>(entity =>
            {
                entity.Property(e => e.SearchCriteria).IsUnicode(false);
            });

            modelBuilder.Entity<TfItemsVideo>(entity =>
            {
                entity.Property(e => e.VideoId).IsUnicode(false);

                entity.Property(e => e.AddedByIp).IsUnicode(false);
            });

            modelBuilder.Entity<TfItemsViewHistory>(entity =>
            {
                entity.Property(e => e.UserId).IsUnicode(false);
            });

            modelBuilder.Entity<TfItemsViewHistory2>(entity =>
            {
                entity.Property(e => e.UserId).IsUnicode(false);
            });

            modelBuilder.Entity<TfItemsWishlist>(entity =>
            {
                entity.HasKey(e => e.WishListId)
                    .HasName("PK_TF_Items__Wishlist");
            });

            modelBuilder.Entity<TfItemsgroupDescriptionUpdatedLog>(entity =>
            {
                entity.Property(e => e.ItemgroupId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TfItemsgroupRelatedDiscount>(entity =>
            {
                entity.Property(e => e.PositionId).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TfItemsgroupSize>(entity =>
            {
                entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.SizeCode).HasDefaultValueSql("((0))");

                //entity.Property(e => e.SizeDesc).IsUnicode(false);

                entity.Property(e => e.TrackingId).IsUnicode(false);

                entity.HasOne(d => d.ItemGroup)
                    .WithMany(p => p.TfItemsgroupSizes)
                    .HasForeignKey(d => d.ItemGroupId)
                    .HasConstraintName("FK_TF_Itemsgroup_Sizes_TF_ItemsGroup");
            });

            modelBuilder.Entity<TfItemsgroupViewHistory>(entity =>
            {
                entity.HasKey(e => e.ViewId)
                    .HasName("PK_ItemView");


                entity.Property(e => e.ViewId).ValueGeneratedOnAdd();

                entity.Property(e => e.UserId).IsUnicode(false);
            });

            modelBuilder.Entity<TfItemsgroupSizeLink>(entity =>
            {
                entity.Property(e => e.ItemgroupId).ValueGeneratedNever();

                entity.Property(e => e.SimilarId).IsUnicode(false);

                entity.Property(e => e.SizeDesc).IsUnicode(false);
            });

            modelBuilder.Entity<TfMenuLink>(entity =>
            {
                entity.Property(e => e.DestinationUrl).IsUnicode(false);

                entity.Property(e => e.ShortTitle).IsUnicode(false);
            });

            modelBuilder.Entity<TfNewsletterSubscriber>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Ipaddress).IsUnicode(false);

                entity.Property(e => e.ValidationCode).IsUnicode(false);
            });

            modelBuilder.Entity<TfOnlineInvoice>(entity =>
            {
                entity.Property(e => e.AlternativeGsm).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.CustomerAddress).IsUnicode(false);

                entity.Property(e => e.CustomerGsm).IsUnicode(false);

                entity.Property(e => e.CustomerName).IsUnicode(false);

                entity.Property(e => e.DownloadCode).IsUnicode(false);

                entity.Property(e => e.DownloadStatus).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.OrderIds).IsUnicode(false);

                entity.Property(e => e.Source).IsUnicode(false);

                entity.Property(e => e.TrackingIds).IsUnicode(false);
            });

            modelBuilder.Entity<TfOrderProduct>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.AffiliateId).IsUnicode(false);

                entity.Property(e => e.AffiliateReferralId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountCode).IsUnicode(false);

                entity.Property(e => e.Ipaddress).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);
            });

            modelBuilder.Entity<TfOrderProductLogger>(entity =>
            {
                entity.Property(e => e.CityId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Codeconfirmed).HasDefaultValueSql("((0))");

                entity.Property(e => e.CurrentStatus).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomerGsm).IsUnicode(false);

                entity.Property(e => e.DeviceSource).IsUnicode(false);

                entity.Property(e => e.DownloadSyncStatus).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExpressCode).IsUnicode(false);

                entity.Property(e => e.IsActivated).HasDefaultValueSql("((0))");

                entity.Property(e => e.OnlineNotes).IsUnicode(false);

                entity.Property(e => e.PaymentIpaddress).IsUnicode(false);

                entity.Property(e => e.ReceiptViews).HasDefaultValueSql("((0))");

                entity.Property(e => e.StateId).HasDefaultValueSql("((0))");

                entity.Property(e => e.TellerId).IsUnicode(false);

                entity.Property(e => e.TellerNumber).IsUnicode(false);

                entity.Property(e => e.TransactionId).IsUnicode(false);
            });

            modelBuilder.Entity<TfOrderReport>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.ReportDetails).IsUnicode(false);
            });

            modelBuilder.Entity<TfOrderVisaUrl>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.TransactionId });

                entity.Property(e => e.TransactionId).IsUnicode(false);

                entity.Property(e => e.TellerId).IsUnicode(false);

                entity.Property(e => e.TellerNumber).IsUnicode(false);

                entity.Property(e => e.Url).IsUnicode(false);

                entity.Property(e => e.Xml).IsUnicode(false);
            });

            modelBuilder.Entity<TfParameter>(entity =>
            {
                entity.Property(e => e.ParamId).ValueGeneratedNever();

                entity.Property(e => e.Ipaddress).IsUnicode(false);

                entity.Property(e => e.ParamName).IsUnicode(false);
            });

            modelBuilder.Entity<TfParameterItem>(entity =>
            {
                entity.HasKey(e => new { e.ParamId, e.ProductId })
                    .HasName("PK_TF_ProductParameters");
            });

            modelBuilder.Entity<TfParameterType>(entity =>
            {
                entity.Property(e => e.ParamTypeId).ValueGeneratedNever();

                entity.Property(e => e.Ipaddress).IsUnicode(false);

                entity.Property(e => e.ParamTypeName).IsUnicode(false);
            });

            modelBuilder.Entity<TfProductAttributesList>(entity =>
            {
                entity.Property(e => e.AttrDesc).IsUnicode(false);
            });

            modelBuilder.Entity<TfProductOrderItem>(entity =>
            {
                entity.Property(e => e.ItemGroupSizeId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductTitle).IsUnicode(false);

                entity.Property(e => e.RefId).IsUnicode(false);

                entity.Property(e => e.TransactionId).IsUnicode(false);
            });

            modelBuilder.Entity<TfRelatedCollection>(entity =>
            {
                entity.HasKey(e => new { e.CollectionId, e.RelatedCollectionId });
            });

            modelBuilder.Entity<TfRelatedDepartment>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.RelatedDepartmentId });
            });

            modelBuilder.Entity<TfRelatedProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.RelatedProductId });
            });

            modelBuilder.Entity<TfSaleEvent>(entity =>
            {
                entity.Property(e => e.SaleEventDesc).IsUnicode(false);

                entity.Property(e => e.SaleEventName).IsUnicode(false);
            });

            modelBuilder.Entity<TfSaleEventItem>(entity =>
            {
                entity.HasKey(e => new { e.SaleEventId, e.ItemGroupId });

                entity.Property(e => e.OfferPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.Position).HasDefaultValueSql("((100))");
            });

            modelBuilder.Entity<TfSalesLog>(entity =>
            {
                entity.Property(e => e.CashBackProcessed).HasDefaultValueSql("((0))");

                entity.Property(e => e.CashBackValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChannelId).HasDefaultValueSql("((0))");

                entity.Property(e => e.CollectionId).HasDefaultValueSql("((0))");

                entity.Property(e => e.CollectionName).IsUnicode(false);

                entity.Property(e => e.ContactId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DepartmentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Gsm).IsUnicode(false);

                entity.Property(e => e.Itemgroupid).HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.SoldBy).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.TrackingId).IsUnicode(false);
            });

            modelBuilder.Entity<TfSalesReceiptLog>(entity =>
            {
                entity.Property(e => e.ReceiptId).ValueGeneratedNever();

                entity.Property(e => e.DiscountCode).IsUnicode(false);
            });

            modelBuilder.Entity<TfShipToAddress>(entity =>
            {
                entity.Property(e => e.Address1).IsUnicode(false);

                entity.Property(e => e.Address2).IsUnicode(false);

                entity.Property(e => e.AlternativeGsm).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.DaytimePhone).IsUnicode(false);

                entity.Property(e => e.DeliverTo).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.NearestBusStop).IsUnicode(false);

                entity.Property(e => e.NearestLandMark).IsUnicode(false);

                entity.Property(e => e.OrderGsm).IsUnicode(false);

                entity.Property(e => e.OrderName).IsUnicode(false);

                entity.Property(e => e.PreferredDeliveryTime).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);
            });

            modelBuilder.Entity<TfShipToNewAddress>(entity =>
            {
                entity.Property(e => e.AddressId).ValueGeneratedNever();

                entity.Property(e => e.Address1).IsUnicode(false);

                entity.Property(e => e.Address2).IsUnicode(false);

                entity.Property(e => e.AlternativePhone).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.DaytimePhone).IsUnicode(false);

                entity.Property(e => e.DeliverTo).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.NearestBusStop).IsUnicode(false);

                entity.Property(e => e.NearestLandMark).IsUnicode(false);

                entity.Property(e => e.PreferredDeliveryTime).IsUnicode(false);
            });

            modelBuilder.Entity<TfSideImage>(entity =>
            {
                entity.Property(e => e.DestinationUrl).IsUnicode(false);

                entity.Property(e => e.ImageTitle).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);
            });

            modelBuilder.Entity<TfStatesCity>(entity =>
            {
                entity.Property(e => e.CityId).ValueGeneratedNever();

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Codavailable).HasDefaultValueSql("((0))");

                entity.Property(e => e.DeliveryCharges).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TfStatesCities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TF_States_Cities_TF_States_DeliveryCharges");
            });

            modelBuilder.Entity<TfStatesDeliveryCharge>(entity =>
            {
                entity.Property(e => e.StateId).ValueGeneratedNever();

                entity.Property(e => e.StateDesc).IsUnicode(false);
            });

            modelBuilder.Entity<TfSubscriber>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.EmailCode).IsUnicode(false);

                entity.Property(e => e.EmailVerified)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Gsm).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.Ipaddress).IsUnicode(false);

                entity.Property(e => e.Subscriber).IsUnicode(false);
            });

            modelBuilder.Entity<TfSubscribersPreset>(entity =>
            {
                entity.Property(e => e.Gsm).IsUnicode(false);

                entity.Property(e => e.Ipaddress).IsUnicode(false);

                entity.Property(e => e.MobileCode).IsUnicode(false);

                entity.Property(e => e.OnlineCode).IsUnicode(false);
            });

            modelBuilder.Entity<TfTheme>(entity =>
            {
                entity.Property(e => e.ThemeDesc).IsUnicode(false);

                entity.Property(e => e.ThemeGroupId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ThemeName).IsUnicode(false);
            });

            modelBuilder.Entity<TfThemeGroup>(entity =>
            {
                entity.Property(e => e.ThemeGroupName).IsUnicode(false);
            });

            modelBuilder.Entity<TfThemeItem>(entity =>
            {
                entity.HasKey(e => new { e.ThemeId, e.ItemGroupId });

                entity.Property(e => e.Position).HasDefaultValueSql("((100))");
            });

            modelBuilder.Entity<TfUnregisteredPublisher>(entity =>
            {
                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Profile).IsUnicode(false);
            });

            modelBuilder.Entity<TfUserKeyword>(entity =>
            {
                entity.Property(e => e.Gsm).IsUnicode(false);

                entity.Property(e => e.Keyword).IsUnicode(false);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gsm).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            modelBuilder.Entity<WebpagesMembership>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__webpages__1788CC4C6383C8BA");

                entity.Property(e => e.UserId).ValueGeneratedNever();
            });

            modelBuilder.Entity<WebpagesOauthMembership>(entity =>
            {
                entity.HasKey(e => new { e.Provider, e.ProviderUserId })
                    .HasName("PK__webpages__F53FC0ED6754599E");
            });

            modelBuilder.Entity<WebpagesRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__webpages__8AFACE1A6B24EA82");
            });

            modelBuilder.Entity<WindowsServicesErrorTest>(entity =>
            {
                entity.Property(e => e.Msg).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
