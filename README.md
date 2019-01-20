# Alfonso

--------------------------------------------------------------------------------------
Project Structure

- ApplicationCore
- Infrastructure
- AlfonsoWeb

AlfonsoWeb -> ApplicationCore -> Infrastructure

--------------------------------------------------------------------------------------
Infrastructure

Implementation of Core interfaces in this project with Entity Framework Core and other dependencies.

Data
	Includes EF Context and tables in this folder. When new entity created, it should add to context and configure in context.
Migrations
	EF add-migration classes.
Repository
	EFRepository and Specification implementation. This class responsible to create queries, includes, where conditions etc..
Services
	Custom services implementation, like email, cron jobs etc.

--------------------------------------------------------------------------------------
ApplicationCore

Development of Domain Logic with abstraction. Interfaces drives business requirements with light implementation.

Entities
	Includes EF Entities which creates sql table with EF Code First Aproach. Some Aggregate folders holds entity and aggregates like Compare - CompareItem, Order - OrderItem.

Interfaces
	Abstraction of Repository - Domain Services (Compare - OrderServices) - Specifications etc.. This interfaces include business logics without ui responsibilities.
	For example ICompareService.AddItemToCompare - RemoveItemToCompare void functions runs here implements Infrastructure. 
	This functions return void Task or Entities or Core related value object. Not UI things.

Services
	Implementation of Domain Services actions. This class uses Repository and Specification in order to performs db related business operations.

Specifications
	Creates custom scripts with using ISpecification interface. Using BaseSpecification managing Criteria, Includes, OrderBy, Paging.
	This specs runs when EF commands working with passing spec. This specs implemented SpecificationEvaluator.cs and creates query to EFRepository.cs in ApplySpecification method.
	This helps create custom queries.

--------------------------------------------------------------------------------------
AlfonsoWeb

Interfaces - Services
	This folders includes Web related logics and after perform operations returns Razor Page elements.
	ICompareViewModelService returns CompareViewModel, so the implementation CompareViewModelService uses repository and specs for retrieve data from db.
	Also this services could use Core - Services classes for void return business actions (CompareService.cs).

ViewModels
	These are DTO related classes for Razor Page. Represent whole Page or part of pages for carry out from db to screen objects.
	CatalogIndexViewModel.cs includes all Index view of project. It contains subviewmodels like CatalogItemViewModel.

Pages
	Razor Pages and cs files for HTTP actions(get-post). 
	
Page Structure
	Shared 
		_Layout , _products, _pagination etc. These are partial htmls in using different pages.
		_products partial is directly using in Index.html for listing products.
	
	Components 
		Includes custom components (ViewComponent) for project. Components run async and connect db with services. 
		Compare -> Custom component for compare box.It includes _Layout partial html, so that means every page using this custom component.
		Usage of _Layout.cshtml -> <vc:compare></vc:compare>

	Compare
		This folder intented for compare page. So it includes Index.html for Compare and ViewModel classes.

	Index.cshtml
		Use Web - Services folder classes and load ViewModel objects with http actions OnGet, OnPost and custom actions.

	Product.cshtml
		Single product page, only load 1 product details.

--------------------------------------------------------------------------------------
Example Use Case

AlfonsoWeb - Services - CatalogService.cs --> this returns ViewModel screen DTOs for use in Razor Page.
	This CatalogService could be uses IRepository and FilterSpecifications directly in order to perform db operations. After that returns UI elements.
	But also Web project Services folder should use Core-Services folder when performing business db operations. 
	Mostly Core-Services should use IRepository and FilterSpecifications directly but this is not mandatory, also AlfonsoWeb-Services could use repository related classes.

Example Code of CatalogService.cs

	        public async Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex, int itemsPage, int? brandId, int? typeId)

	        var filterSpecification = new CatalogFilterSpecification(brandId, typeId);
            var filterPaginatedSpecification = new CatalogFilterPaginatedSpecification(itemsPage * pageIndex, itemsPage, brandId, typeId);

            // the implementation below using ForEach and Count. We need a List.
            var itemsOnPage = _itemRepository.List(filterPaginatedSpecification).ToList();
            var totalItems = _itemRepository.Count(filterSpecification);

After that load view models in Index.cshtml;

		public CatalogIndexViewModel CatalogModel { get; set; } = new CatalogIndexViewModel();
        public CompareViewModel CompareModel { get; set; } = new CompareViewModel();

        public async Task OnGet(CatalogIndexViewModel catalogModel, int? pageId)
        {
            CatalogModel = await _catalogService.GetCatalogItems(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterApplied, catalogModel.TypesFilterApplied);            
        }

--------------------------------------------------------------------------------------


