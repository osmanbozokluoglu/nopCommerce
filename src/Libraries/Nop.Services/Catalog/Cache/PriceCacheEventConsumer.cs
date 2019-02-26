using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Configuration;

using Nop.Core.Events;
using Nop.Services.Events;

namespace Nop.Services.Catalog.Cache
{
    /// <summary>
    /// Price cache event consumer (used for caching of prices)
    /// </summary>
    public partial class PriceCacheEventConsumer :
        //settings
        IConsumer<EntityUpdatedEvent<Setting>>,
        //categories
        IConsumer<EntityInsertedEvent<Category>>,
        IConsumer<EntityUpdatedEvent<Category>>,
        IConsumer<EntityDeletedEvent<Category>>,
        //product categories
        IConsumer<EntityInsertedEvent<ProductCategory>>,
        IConsumer<EntityUpdatedEvent<ProductCategory>>,
        IConsumer<EntityDeletedEvent<ProductCategory>>,
        //products
        IConsumer<EntityInsertedEvent<Product>>,
        IConsumer<EntityUpdatedEvent<Product>>,
        IConsumer<EntityDeletedEvent<Product>>,
        //tier prices
        IConsumer<EntityInsertedEvent<TierPrice>>,
        IConsumer<EntityUpdatedEvent<TierPrice>>,
        IConsumer<EntityDeletedEvent<TierPrice>>
    {
        #region Fields

        private readonly IStaticCacheManager _cacheManager;

        #endregion

        #region Ctor

        public PriceCacheEventConsumer(IStaticCacheManager cacheManager)
        {
            this._cacheManager = cacheManager;
        }

        #endregion

        #region Methods

        public void HandleEvent(EntityUpdatedEvent<Setting> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductPricePatternCacheKey);
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductCategoryIdsPatternCacheKey);
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductManufacturerIdsPatternCacheKey);
        }

        #region Categories

        public void HandleEvent(EntityInsertedEvent<Category> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductCategoryIdsPatternCacheKey);
        }

        public void HandleEvent(EntityUpdatedEvent<Category> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductCategoryIdsPatternCacheKey);
        }

        public void HandleEvent(EntityDeletedEvent<Category> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductCategoryIdsPatternCacheKey);
        }
        
        #endregion

        #region Product categories

        public void HandleEvent(EntityInsertedEvent<ProductCategory> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductPricePatternCacheKey);
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductCategoryIdsPatternCacheKey);
        }

        public void HandleEvent(EntityUpdatedEvent<ProductCategory> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductPricePatternCacheKey);
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductCategoryIdsPatternCacheKey);
        }

        public void HandleEvent(EntityDeletedEvent<ProductCategory> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductPricePatternCacheKey);
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductCategoryIdsPatternCacheKey);
        }

        #endregion

        #region Products

        public void HandleEvent(EntityInsertedEvent<Product> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductPricePatternCacheKey);
        }

        public void HandleEvent(EntityUpdatedEvent<Product> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductPricePatternCacheKey);
        }

        public void HandleEvent(EntityDeletedEvent<Product> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductPricePatternCacheKey);
        }

        #endregion

        #region Tier prices

        public void HandleEvent(EntityInsertedEvent<TierPrice> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductPricePatternCacheKey);
        }

        public void HandleEvent(EntityUpdatedEvent<TierPrice> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductPricePatternCacheKey);
        }

        public void HandleEvent(EntityDeletedEvent<TierPrice> eventMessage)
        {
            _cacheManager.RemoveByPattern(NopCatalogDefaults.ProductPricePatternCacheKey);
        }

        #endregion

        

        #endregion
    }
}