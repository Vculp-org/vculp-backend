namespace Vculp.Api.Common
{
    public static class RouteNames
    {
        #region Customers Route Names
        // Species
        public const string CustomersGetAllSpecies = "CustomersGetAllSpecies";
        public const string CustomersGetSpeciesById = "CustomersGetSpeciesById";
        public const string CustomersGetAllSpeciesCategories = "CustomersGetAllSpeciesCategories";
        public const string CustomersGetSpeciesCategoryById = "CustomersGetSpeciesCategoryById";
        public const string CustomersGetAllSpeciesSubSpecies = "CustomersGetAllSubSpecies";
        public const string CustomersGetSpeciesSubSpeciesById = "CustomersGetSpeciesSubSpeciesById";
        public const string CustomersGetAllSpeciesStockTypes = "CustomersGetAllSpeciesStockTypes";
        public const string CustomersGetSpeciesStockTypeById = "CustomersGetSpeciesStockTypeById";

        // Categories
        public const string CustomersGetAllCategories = "CustomersGetAllCategories";
        public const string CustomersGetCategoryById = "CustomersGetCategoryById";
        public const string CustomersCreateCategory = "CustomersCreateCategory";
        public const string CustomersUpdateCategory = "CustomersUpdateCategory";
        public const string CustomersDeleteCategory = "CustomersDeleteCategory";
        public const string CustomersGetAllCategoryMerchants = "CustomersGetAllCategoryMerchants";
        public const string CustomersGetCategoryMerchantById = "CustomersGetCategoryMerchantsById";
        public const string CustomersGetAllCategoryIntegrators = "CustomersGetAllCategoryIntegrators";
        public const string CustomersGetCategoryIntegratorById = "CustomersGetCategoryIntegratorById";
        public const string CustomersGetAllCategoryCustomerGroups = "CustomersGetAllCategoryCustomerGroups";
        public const string CustomersGetCategoryCustomerGroupById = "CustomersGetCategoryCustomerGroupById";
        public const string CustomersAssociateIntegratorToCategory = "CustomersAssociateIntegratorToCategory";
        public const string CustomersDisassociateIntegratorFromCategory = "CustomersDisassociateIntegratorFromCategory";
        public const string CustomersAssociateMerchantToCategory = "CustomersAssociateMerchantToCategory";
        public const string CustomersDisassociateMerchantFromCategory = "CustomersDisassociateMerchantFromCategory";
        public const string CustomersAssociateCustomerGroupToCategory = "CustomersAssociateCustomerGroupToCategory";
        public const string CustomersDisassociateCustomerGroupFromCategory = "CustomersDisassociateCustomerGroupFromCategory";
        public const string CustomersAssociateSpeciesToCategory = "CustomersAssociateSpeciesToCategory";
        public const string CustomersDisassociateSpeciesFromCategory = "CustomersDisassociateSpeciesFromCategory";

        //Merchants
        public const string CustomersGetAllMerchants = "CustomersGetAllMerchants";
        public const string CustomersGetMerchantById = "CustomersGetMerchantById";
        public const string CustomersCreateMerchant = "CustomersCreateMerchant";
        public const string CustomersUpdateMerchant = "CustomersUpdateMerchant";
        public const string CustomersDeleteMerchant = "CustomersDeleteMerchant";

        //Groups
        public const string CustomersGetAllGroups = "CustomersGetAllGroups";
        public const string CustomersGetGroupById = "CustomersGetGroupById";
        public const string CustomersCreateGroup = "CustomersCreateGroup";
        public const string CustomersUpdateGroup = "CustomersUpdateGroup";
        public const string CustomersDeleteGroup = "CustomersDeleteGroup";

        //Price Lists
        public const string CustomersGetAllPriceLists = "CustomersGetAllPriceLists";
        public const string CustomersGetPriceListById = "CustomersGetPriceListById";

        //Integrators
        public const string CustomersGetAllIntegrators = "CustomersGetAllIntegrators";
        public const string CustomersGetIntegratorById = "CustomersGetIntegratorById";
        public const string CustomersCreateIntegrator = "CustomersCreateIntegrator";
        public const string CustomersUpdateIntegrator = "CustomersUpdateIntegrator";
        public const string CustomersDeleteIntegrator = "CustomersDeleteIntegrator";

        //Integrator Price lists
        public const string CustomersGetAllIntegratorPriceLists = "CustomersGetAllIntegratorPriceLists";
        public const string CustomersAssignIntegratorPriceList = "CustomersAssignIntegratorPriceList";
        public const string CustomersRemoveIntegratorPriceList = "CustomersRemoveIntegratorPriceList";

        //Merchant Price lists
        public const string CustomersGetAllMerchantPriceLists = "CustomersGetAllMerchantPriceLists";
        public const string CustomersAssignMerchantPriceList = "CustomersAssignMerchantPriceList";
        public const string CustomersRemoveMerchantPriceList = "CustomersRemoveMerchantPriceList";

        //Group Price lists
        public const string CustomersGetAllGroupPriceLists = "CustomersGetAllGroupPriceLists";
        public const string CustomersAssignGroupPriceList = "CustomersAssignGroupPriceList";
        public const string CustomersRemoveGroupPriceList = "CustomersRemoveGroupPriceList";

        //LeadTypes
        public const string CustomersGetAllLeadTypes = "CustomersGetAllLeadTypes";
        public const string CustomersGetLeadTypeById = "CustomersGetLeadTypeById";
        public const string CustomersGetAllLeadTypeCategories = "CustomersGetAllLeadTypeCategories";
        public const string CustomersGetLeadTypeCategoryById = "CustomersGetLeadTypeCategoryById";

        // Counties
        public const string CustomersGetAllCounties = "CustomersGetAllCounties";
        public const string CustomersGetCountyById = "CustomersGetCountyById";

        //Vets
        public const string CustomersGetAllVets = "CustomersGetAllVets";
        public const string CustomersGetVetById = "CustomersGetVetById";
        public const string CustomersCreateVet = "CustomersCreateVet";
        public const string CustomersUpdateVet = "CustomersUpdateVet";

        //SalesReps
        public const string CustomersGetAllSalesReps = "CustomersGetAllSalesReps";
        public const string CustomersGetSalesRepById = "CustomersGetSalesRepById";
        public const string CustomersCreateSalesRep = "CustomersCreateSalesRep";
        public const string CustomersUpdateSalesRep = "CustomersUpdateSalesRep";
        public const string CustomersDeleteSalesRep = "CustomersDeleteSalesRep";

        //SalesReps
        public const string CustomersGetAllBusinessTypes = "CustomersGetAllBusinessTypes";
        public const string CustomersGetBusinessTypeById = "CustomersGetBusinessTypeById";

        public const string CustomersGetSalesRepCustomers = "CustomersGetSalesRepCustomers";
        public const string CustomersGetSalesRepCustomersDeliverySites = "CustomersGetSalesRepCustomersDeliverySites";
        public const string CustomersGetSalesRepCustomersNotes = "CustomersGetSalesRepCustomersNotes";
        public const string CustomersGetSalesRepCustomer = "CustomersGetSalesRepCustomer";
        public const string CustomersGetSalesRepOrders = "CustomersGetSalesRepOrders";
        public const string CustomersGetSalesRepOrder = "CustomersGetSalesRepOrder";
        public const string CustomersGetSalesRepOrderLineNotes = "CustomersGetSalesRepOrderLineNotes";
        public const string CustomersAuthenticatedSalesRepCreateOrder = "CustomersAuthenticatedSalesRepCreateOrder";

        //SortCodes
        public const string CustomersGetAllSortCodes = "CustomersGetAllSortCodes";
        public const string CustomersGetSortCodeById = "CustomersGetSortCodeById";
        public const string CustomersCreateSortCode = "CustomersCreateSortCode";
        public const string CustomersUpdateSortCode = "CustomersUpdateSortCode";
        public const string CustomersDeleteSortCode = "CustomersDeleteSortCode";

        //CustomerAppProductHistoryConfiguration
        public const string CustomersGetAllCustomerAppProductHistoryConfigurations = "CustomersGetAllCustomerAppProductHistoryConfigurations";
        public const string CustomersGetCustomerAppProductHistoryConfigurationById = "CustomersGetCustomerAppProductHistoryConfigurationById";
        public const string CustomersCreateCustomerAppProductHistoryConfiguration = "CustomersCreateCustomerAppProductHistoryConfiguration";
        public const string CustomersUpdateCustomerAppProductHistoryConfiguration = "CustomersUpdateCustomerAppProductHistoryConfiguration";
        public const string CustomersDeleteCustomerAppProductHistoryConfiguration = "CustomersDeleteCustomerAppProductHistoryConfiguration";

        //SalesRepSortCodes
        public const string CustomersGetAllSalesRepSortCodes = "CustomersGetAllSalesRepSortCodes";
        public const string CustomersGetSalesRepSortCodeById = "CustomersGetSalesRepSortCodeById";
        public const string CustomersAssociateSortCodeToSalesRep = "CustomersAssociateSortCodeToSalesRep";
        public const string CustomersDisassociateSortCodeToSalesRep = "CustomersDisassociateSortCodeToSalesRep";

        //Customer
        public const string CustomersCreateCustomer = "CustomersCreateCustomer";
        public const string CustomersUpdateCustomer = "CustomersUpdateCustomer";
        public const string CustomersUpdateCustomerAccountingDetails = "CustomersUpdateCustomerAccountingDetails";
        public const string CustomersBulkCustomersLiveInvoicing = "CustomersBulkCustomersLiveInvoicing";
        public const string CustomersAllCustomers = "CustomersAllCustomers";
        public const string CustomersGetCustomerByCode = "CustomersGetCustomerByCode";
        public const string CustomersGetCustomerNotes = "CustomersGetCustomerNotes";
        public const string CustomersGetCustomerNoteById = "CustomersGetCustomerNoteById";
        public const string CustomersUpdateCustomerNote = "CustomersUpdateCustomerNote";
        public const string CustomersCreateCustomerNote = "CustomersCreateCustomerNote";
        public const string CustomersDeleteCustomerNote = "CustomersDeleteCustomerNote";
        public const string CustomersGetCustomerDeliverySites = "CustomersGetCustomerDeliverySites";
        public const string CustomersCustomerDeliverySiteCreate = "CustomersCustomerDeliverySiteCreate";
        public const string CustomersCustomerDeliverySiteUpdate = "CustomersCustomerDeliverySiteUpdate";
        public const string CustomersCustomerDeliverySiteDelete = "CustomersCustomerDeliverySiteDelete";
        public const string CustomersGetCustomerDeliverySiteById = "CustomersGetCustomerDeliverySiteById";
        public const string CustomersGetCustomerDeliverySiteContacts = "CustomersGetCustomerDeliverySiteContacts";
        public const string CustomersGetCustomerDeliverySiteContactById = "CustomersGetCustomerDeliverySiteContactById";
        public const string CustomersCreateCustomerDeliverySiteContact = "CustomersCreateCustomerDeliverySiteContact";
        public const string CustomersUpdateCustomerDeliverySiteContact = "CustomersUpdateCustomerDeliverySiteContact";
        public const string CustomersDeleteCustomerDeliverySiteContact = "CustomersDeleteCustomerDeliverySiteContact";
        public const string CustomersGetCustomerDeliverySiteNotes = "CustomersGetCustomerDeliverySiteNotes";
        public const string CustomersGetCustomerDeliverySiteNoteById = "CustomersGetCustomerDeliverySiteNoteById";
        public const string CustomersUpdateCustomerDeliverySiteNote = "CustomersUpdateCustomerDeliverySiteNote";
        public const string CustomersCreateCustomerDeliverySiteNote = "CustomersCreateCustomerDeliverySiteNote";
        public const string CustomersDeleteCustomerDeliverySiteNote = "CustomersDeleteCustomerDeliverySiteNote";
        public const string CustomersGetCustomerStockCounts = "CustomersGetCustomerStockCounts";
        public const string CustomersGetDeliverySiteStockCounts = "CustomersGetDeliverySiteStockCounts";
        public const string CustomersUpdateDeliverySiteStockCounts = "CustomersUpdateDeliverySiteStockCounts";
        public const string CustomersGetCustomerPricingInfo = "CustomersGetCustomerPricingInfo";
        public const string CustomersUpdateCustomerPricingInfo = "CustomersUpdateCustomerPricingInfo";
        public const string CustomersGetCustomerCustomProfileById = "CustomersGetCustomerCustomProfileById";
        public const string CustomersUpdateCustomProfile = "CustomersUpdateCustomProfile";
        public const string CustomersGetAllDeliverySites = "CustomersGetAllDeliverySites";
        public const string CustomersGetAllAbmSortCodes = "CustomersGetAllAbmSortCodes";
        public const string CustomersGetAllAbmSalesAnalysisCodes = "CustomersGetAllAbmSalesAnalysisCodes";

        //Currency
        public const string CustomersGetAllCurrencies = "CustomersGetAllCurrencies";
        public const string CustomersGetCurrencyById = "CustomersGetCurrencyById";

        //CRM notes
        public const string CustomersAddCrmNote = "CustomersAddCrmNote";
        public const string CustomersGetAllCrmNotes = "CustomersGetAllCrmNotes";
        public const string CustomersGetCrmNoteById = "CustomersGetCrmNoteById";

        //Additive notes
        public const string CustomersCreateAdditiveNote = "CustomersCreateAdditiveNote";
        public const string CustomersGetAllAdditiveNotes = "CustomersGetAllAdditiveNotes";
        public const string CustomersGetAdditiveNoteById = "CustomersGetAdditiveNoteById";

        //Audit log entries
        public const string CustomersGetAllAuditLogEntries = "CustomersGetAllAuditLogEntries";
        public const string CustomersGetAuditLogEntryById = "CustomersGetAuditLogEntryById";

        //Authenticated Customer
        public const string CustomersAuthenticatedCustomer = "CustomersAuthenticatedCustomer";
        public const string CustomersAuthenticatedCustomerDeliverySites = "CustomersAuthenticatedCustomerDeliverySites";
        public const string CustomersAuthenticatedCustomerNotes = "CustomersAuthenticatedCustomerNotes";
        public const string CustomersAuthenticatedCustomerDeleteNote = "CustomersAuthenticatedCustomerDeleteNote";
        public const string CustomersAuthenticatedCustomerCreateOrder = "CustomersAuthenticatedCustomerCreateOrder";
        public const string CustomersAuthenticatedCustomerAdditiveHistory = "CustomersAuthenticatedCustomerAdditiveHistory";
        public const string CustomersAuthenticatedCustomerProductCatalogItems = "CustomersAuthenticatedCustomerProductCatalogItems";

        // ABM Group
        public const string CustomersGetAllAbmGroups = "CustomersGetAllAbmGroups";

        //VATCodes
        public const string CustomersGetAllVATCodes = "CustomersGetAllVATCodes";

        public const string CustomersUpdateCustomerDeliverySiteEstimatedCoordinates = "CustomersUpdateCustomerDeliverySiteEstimatedCoordinates";

        #endregion

        #region Products Route Names

        //DeliveryOptions
        public const string ProductsGetAllDeliveryOptions = "ProductsGetAllDeliveryOptions";
        public const string ProductsGetDeliveryOptionById = "ProductsGetDeliveryOptionById";
        public const string ProductsUploadDeliveryOptionImage = "ProductsUploadDeliveryOptionImage";
        public const string ProductsDeleteDeliveryOptionImage = "ProductsDeleteDeliveryOptionImage";
        public const string ProductsGetDeliveryOptionImage = "ProductsGetDeliveryOptionImage";

        // Species
        public const string ProductsGetAllSpecies = "ProductsGetAllSpecies";
        public const string ProductsGetSpeciesById = "ProductsGetSpeciesById";

        // SubSpecies
        public const string ProductsGetAllSpeciesSubSpecies = "ProductsGetAllSpeciesSubSpecies";
        public const string ProductsGetSpeciesSubSpeciesById = "ProductsGetSpeciesSubSpeciesById";
        public const string ProductsCreateSubSpecies = "ProductsCreateSubSpecies";
        public const string ProductsUpdateSubSpecies = "ProductsUpdateSubSpecies";

        // SunGroup ProductForms 
        public const string ProductsGetAllSubGroupProductForms = "ProductsGetAllSubGroupProductForms";
        public const string ProductsGetSubGroupSubSpeciesProductFormByCode = "ProductsGetSubGroupSubSpeciesProductFormByCode";
        public const string ProductsAssociateSubGroupProductForm = "ProductsAssociateubGroupProductForm";
        public const string ProductsDisassociateSubGroupProductForm = "ProductsDisassociateubGroupProductForm";

        // BagSizes
        public const string ProductsGetAllBagSizes = "ProductsGetAllBagSizes";
        public const string ProductsGetBagSizeById = "ProductsGetBagSizeById";

        // Currencies
        public const string ProductsGetAllCurrencies = "ProductsGetAllCurrencies";
        public const string ProductsGetCurrencyById = "ProductsGetCurrencyById";

        // Price Lists
        public const string ProductsGetAllPriceLists = "ProductsGetAllPriceLists";
        public const string ProductsGetPriceListById = "ProductsGetPriceListById";
        public const string ProductsCreatePriceList = "ProductsCreatePriceList";
        public const string ProductsUpdatePriceList = "ProductsUpdatePriceList";
        public const string ProductsDeletePriceList = "ProductsDeletePriceList";
        public const string ProductsGetAllPriceListsPendingPriceUpdateOverride = "ProductsGetAllPriceListsPendingPriceUpdateOverride";
        public const string ProductsUpdatePriceOfPriceListPendingPriceUpdateOverride = "ProductsUpdatePriceOfPriceListPendingPriceUpdateOverride";
        public const string ProductsDeletePriceListPendingPriceChange = "ProductsDeletePriceListPendingPriceChange";


        // Customers
        public const string ProductsAllCustomers = "ProductsAllCustomers";
        public const string ProductsGetCustomerByCode = "ProductsGetCustomerByCode";
        public const string ProductsGetCustomerPendingPriceChanges = "ProductsGetCustomerPendingPriceChanges";
        public const string ProductsUpdatePendingCustomerSpecificPriceChanges = "ProductsUpdatePendingCustomerSpecificPriceChanges";
        public const string ProductsDeletePendingCustomerSpecificPriceChange = "ProductsDeletePendingCustomerSpecificPriceChange";
        public const string ProductsGetCustomerPricesPendingRemoval = "ProductsGetCustomerPricesPendingRemoval";

        // Formulation
        public const string ProductsGetAllFormulations = "ProductsGetAllFormulations";
        public const string ProductsGetFormulationByCode = "ProductsGetFormulationByCode";

        // PhysicalForms
        public const string ProductsGetAllPhysicalForms = "ProductsGetAllPhysicalForms";
        public const string ProductsGetPhysicalFormByCode = "ProductsGetPhysicalFormByCode";
        public const string ProductsCreatePhysicalForm = "ProductsCreatePhysicalForm";
        public const string ProductsUpdatePhysicalForm = "ProductsUpdatePhysicalForm";
        public const string ProductsDeletePhysicalForm = "ProductsDeletePhysicalForm";

        // TextGroup
        public const string OrdersGetAllTextGroups = "OrdersGetAllTextGroups";
        public const string OrdersGetTextGroupByCode = "OrdersGetTextGroupByCode";
        public const string OrdersCreateTextGroup = "OrdersCreateTextGroup";
        public const string OrdersUpdateTextGroup = "OrdersUpdateTextGroup";
        public const string OrdersDeleteTextGroup = "OrdersDeleteTextGroup";
        // Product
        public const string ProductsAddProduct = "ProductsAddProduct";
        public const string ProductsUpdateProduct = "ProductsUpdateProduct";
        public const string ProductsGetAllProducts = "ProductsGetAllProducts";
        public const string ProductsGetProductByCode = "ProductsGetProductByCode";
        public const string ProductsUploadProductImage = "ProductsUploadProductImage";
        public const string ProductsGetProductImage = "ProductsGetProductImage";
        public const string ProductsDeleteProductImage = "ProductsDeleteProductImage";
        public const string ProductsGetCustomProfileByProductId = "ProductsGetCustomProfileByProductId";
        public const string ProductsUpdateCustomProfile = "ProductsUpdateCustomProfile";

        // Product Configuration
        public const string ProductsAddProductConfiguration = "ProductsAddProductConfiguration";
        public const string ProductsUpdateProductConfiguration = "ProductsUpdateProductConfiguration";
        public const string ProductsDeleteProductConfiguration = "ProductsDeleteProductConfiguration";

        //PriceListPrices
        public const string ProductsGetAllProductPriceListPrices = "ProductsGetAllProductPriceListPrices";
        public const string ProductsGetPriceListPricesForSpecies = "ProductsGetPriceListPricesForSpecies";
        public const string ProductsGetPriceListProductPrices = "ProductsGetPriceListProductPrices";
        public const string ProductsGetSingleProductPriceListPrices = "ProductsGetSingleProductPriceListPrices";
        public const string ProductsCreateProductPriceListPrices = "ProductsCreateProductPriceListPrices";
        public const string ProductsUpdateProductPriceListPrices = "ProductsUpdateProductPriceListPrices";
        public const string ProductsDeleteProductPriceListPrices = "ProductsDeleteProductPriceListPrices";

        //CustomerSpecificProductPrices
        public const string ProductsGetProductCustomerPrices = "ProductsGetProductCustomerPrices";
        public const string ProductsCreateProductCustomerPrices = "ProductsCreateProductCustomerPrices";
        public const string ProductsUpdateProductCustomerPrices = "ProductsUpdateProductCustomerPrices";
        public const string ProductsDeleteProductCustomerPrices = "ProductsDeleteProductCustomerPrices";
        public const string ProductsGetSingleProductCustomerSpecificPrices = "ProductsGetSingleProductCustomerSpecificPrices";
        public const string ProductsGetCustomerProductPrices = "ProductsGetCustomerProductPrices";

        //DrugActiveAgents
        public const string ProductsGetAllDrugActiveAgents = "ProductsGetAllDrugActiveAgents";
        public const string ProductsGetSingleDrugActiveAgent = "ProductsGetSingleDrugActiveAgent";
        public const string ProductsCreateDrugActiveAgent = "ProductsCreateDrugActiveAgent";
        public const string ProductsUpdateDrugActiveAgent = "ProductsUpdateDrugActiveAgent";
        public const string ProductsDeleteDrugActiveAgent = "ProductsDeleteDrugActiveAgent";

        //Diseases
        public const string ProductsGetAllDiseases = "ProductsGetAllDiseases";
        public const string ProductsGetSingleDisease = "ProductsGetSingleDisease";
        public const string ProductsCreateDisease = "ProductsCreateDisease";
        public const string ProductsUpdateDisease = "ProductsUpdateDisease";
        public const string ProductsDeleteDisease = "ProductsDeleteDisease";

        //AgeRanges
        public const string ProductsGetAllAgeRanges = "ProductsGetAllAgeRanges";
        public const string ProductsGetSingleAgeRange = "ProductsGetSingleAgeRange";

        //Medications
        public const string ProductsGetAllMedications = "ProductsGetAllMedications";
        public const string ProductsGetSingleMedication = "ProductsGetSingleMedication";
        public const string ProductsGetMedicationProduct = "ProductsGetMedicationProduct";
        public const string ProductsGetMedicationProducts = "ProductsGetMedicationProducts";
        public const string ProductsCreateMedicationProductAssociation = "ProductsCreateMedicationProductAssociation";
        public const string ProductsUpdateMedicationProductAssociation = "ProductsUpdateMedicationProductAssociation";
        public const string ProductsDeleteMedicationProductAssociation = "ProductsDeleteMedicationProductAssociation";
        public const string ProductsCreateMedication = "ProductsCreateMedication";
        public const string ProductsUpdateMedication = "ProductsUpdateMedication";
        public const string ProductsCreateDrugProductForMedication = "ProductsCreateDrugProductForMedication";
        public const string ProductsUpdateDrugProductForMedication = "ProductsUpdateDrugProductForMedication";
        public const string ProductsDeleteDrugProductForMedication = "ProductsDeleteDrugProductForMedication";
        public const string ProductsGetAllMedicationPrices = "ProductsGetAllMedicationPrices";
        public const string ProductsGetMedicationsWithPrices = "ProductsGetMedicationsWithPrices";
        public const string ProductsGetSingleMedicationPrice = "ProductsGetSingleMedicationPrice";
        public const string ProductsCreatePriceForMedication = "ProductsCreatePriceForMedication";
        public const string ProductsUpdatePriceForMedication = "ProductsUpdatePriceForMedication";
        public const string ProductsDeletePriceForMedication = "ProductsDeletePriceForMedication";

        //ProductWeights
        public const string ProductsGetAllWeights = "ProductsGetAllWeights";
        public const string ProductsGetWeightById = "ProductsGetWeightById";

        //Audit log entries
        public const string ProductsGetAllAuditLogEntries = "ProductsGetAllAuditLogEntries";
        public const string ProductsGetAuditLogEntryById = "ProductsGetAuditLogEntryById";

        //Drug Products
        public const string ProductsGetAllDrugProducts = "ProductsGetAllDrugProducts";
        public const string ProductsGetDrugProductById = "ProductsGetDrugProductById";
        public const string ProductsCreateDrugProduct = "ProductsCreateDrugProduct";
        public const string ProductsUpdateDrugProduct = "ProductsUpdateDrugProduct";
        public const string ProductsDeleteDrugProduct = "ProductsDeleteDrugProduct";
        public const string ProductsCreateActiveAgentContributionForDrugProduct = "ProductsCreateActiveAgentContributionForDrugProduct";
        public const string ProductsUpdateActiveAgentContributionForDrugProduct = "ProductsUpdateActiveAgentContributionForDrugProduct";
        public const string ProductsDeleteActiveAgentContributionForDrugProduct = "ProductsDeleteActiveAgentContributionForDrugProduct";

        //Price
        public const string ProductsGetPrices = "ProductsGetPrices";
        public const string MedicationGetPrices = "MedicationGetPrices";
        public const string PriceListsPrices = "PriceListsPrices";




        //Price List Pending Price Update Overrides
        public const string ProductsCreatePriceListPendingPriceUpdateOverrides = "ProductsCreatePriceListPendingPriceUpdateOverrides";
        public const string ProductsUpdatePriceListPendingPriceUpdateOverrides = "ProductsUpdatePriceListPendingPriceUpdateOverrides";
        public const string ProductsDeletePriceListPendingPriceUpdateOverrides = "ProductsDeletePriceListPendingPriceUpdateOverrides";


        // PriceListPricesPendingRemoval
        public const string ProductsCreatePriceListPricesPendingRemoval = "ProductsCreatePriceListPricesPendingRemoval";
        public const string ProductsGetAllPriceListPricesPendingRemoval = "ProductsGetAllPriceListPricesPendingRemoval";

        // PendingPriceListPriceChange
        public const string ProductsCreatePendingPriceListPriceChange = "ProductsCreatePendingPriceListPriceChange";

        public const string ProductsPendingPriceListPricesRefresh = "ProductsPendingPriceListPricesRefresh";
        #endregion

        #region Orders Route Names

        // Order Vwds
        public const string OrdersGetSingleVwd = "OrdersGetSingleVwd";
        public const string OrdersGetAllVwds = "OrdersGetAllVwds";
        public const string OrdersGetCustomerVwds = "OrdersGetCustomerVwds";
        public const string OrdersCreateVwd = "OrdersCreateVwd";
        public const string OrdersUpdateVwd = "OrdersUpdateVwd";
        public const string OrdersGetAllVetsVwds = "OrdersGetAllVetsVwds";
        public const string OrdersGetVetsVwd = "OrdersGetVetsVwd";
        public const string OrdersUpdateVetsVwd = "OrdersUpdateVetsVwd";
        public const string OrdersUpdateVwdsStatus = "OrdersUpdateVwdsStatus";
        public const string OrdersUpdateVwdPrintingStatus = "OrdersUpdateVwdPrintingStatus";
        public const string OrdersGetApprovedVwdDocument = "OrdersGetApprovedVwdDocument";

        // Order Sources
        public const string OrdersGetAllSources = "OrdersGetAllSources";
        public const string OrdersGetSourceById = "OrdersGetSourceById";
        public const string OrdersCreateOrderSource = "CreateOrderSource";
        public const string OrdersUpdateOrderSource = "UpdateOrderSource";

        // SubGroups
        public const string OrdersGetAllSubGroups = "OrdersGetAllSubGroups";
        public const string OrdersGetSubGroupById = "OrdersGetSubGroupById";
        public const string OrdersCreateSubGroup = "CreateSubGroup";
        public const string OrdersUpdateSubGroup = "UpdateSubGroup";
        public const string OrdersDeleteSubGroup = "OrdersDeleteSubGroup";

        // UnitsOfMeasure
        public const string OrdersGetAllUnitsOfMeasure = "OrdersGetAllUnitsOfMeasure";
        public const string OrdersGetUnitOfMeasureById = "OrdersGetUnitOfMeasureById";
        public const string OrdersCreateUnitOfMeasure = "CreateUnitOfMeasure";
        public const string OrdersUpdateUnitOfMeasure = "UpdateUnitOfMeasure";
        public const string OrdersDeleteUnitOfMeasure = "OrdersDeleteUnitOfMeasure";

        // Customer Delivery Sites
        public const string OrdersGetCustomerDeliverySites = "OrdersGetCustomerDeliverySites";
        public const string OrdersGetCustomerDeliverySiteById = "OrdersGetCustomerDeliverySiteById";

        //Medications
        public const string OrdersGetMedications = "OrdersGetMedications";
        public const string OrdersGetMedicationByCode = "OrdersGetMedicationByCode";

        //Product Configurations
        public const string OrdersGetProductConfigurations = "OrdersGetProductConfigurations";
        public const string OrdersGetProductConfigurationByCode = "OrdersGetProductConfigurationByCode";

        //Orders
        public const string OrdersCreateOrder = "OrdersCreateOrder";
        public const string OrdersUpdateOrder = "OrdersUpdateOrder";
        public const string OrdersSendOrderToProduction = "OrdersSendOrderToProduction";
        public const string OrdersCancelOrder = "OrdersCancelOrder";
        public const string OrdersUnblockOrder = "OrdersUnblockOrder";
        public const string OrdersGetAllOrders = "OrdersGetAllOrders";
        public const string OrdersGetOrderByOrderNumber = "OrdersGetOrderByOrderNumber";

        // Order Custom Profiles
        public const string OrdersGetCustomProfileById = "OrdersGetCustomProfileById";
        public const string OrdersUpdateCustomProfile = "OrdersUpdateCustomProfile";

        //Product Medications
        public const string OrdersGetSalesRepSyncProductMedications = "OrdersGetSalesRepSyncProductMedications";
        public const string OrdersGetProductMedications = "OrdersGetProductMedications";
        public const string OrdersGetProductMedicationByCode = "OrdersGetProductMedicationByCode";

        //Order Lines
        public const string OrdersGetAllOrderLines = "OrdersGetAllOrderLines";
        public const string OrdersGetAllOrderOrderLines = "OrdersGetAllOrderOrderLines";
        public const string OrdersGetCustomerOrderLines = "OrdersGetCustomerOrderLines";
        public const string OrdersGetOrderLineById = "OrdersGetOrderLineById";
        public const string OrdersCreateOrderLine = "OrdersCreateOrderLine";
        public const string OrdersUpdateOrderLine = "OrdersUpdateOrderLine";
        public const string OrdersDeleteOrderLine = "OrdersDeleteOrderLine";
        public const string OrdersCancelOrderLine = "OrdersCancelOrderLine";

        //Order Line Notes
        public const string OrdersGetAllOrderLineNotes = "OrdersGetAllOrderLineNotes";
        public const string OrdersGetOrderLineNoteById = "OrdersGetOrderLineNoteById";
        public const string OrdersCreateOrderLineNote = "OrdersCreateOrderLineNote";
        public const string OrdersUpdateOrderLineNote = "OrdersUpdateOrderLineNote";
        public const string OrdersDeleteOrderLineNote = "OrdersDeleteOrderLineNote";

        //Order Notes
        public const string OrdersGetAllOrderNotes = "OrdersGetAllOrderNotes";
        public const string OrdersGetGroupedOrderNotes = "OrdersGetGroupedOrderNotes";
        public const string OrdersGetOrderNoteById = "OrdersGetOrderNoteById";
        public const string OrdersCreateOrderNote = "OrdersCreateOrderNote";
        public const string OrdersUpdateOrderNote = "OrdersUpdateOrderNote";
        public const string OrdersDeleteOrderNote = "OrdersDeleteOrderNote";

        //SubSpecies sub groups
        public const string OrdersGetAllSubSpeciesSubGroups = "OrdersGetAllSubSpeciesSubGroups";
        public const string OrdersGetSubSpeciesSubGroupById = "OrdersGetSubSpeciesSubGroupById";
        public const string OrdersCreateSubSpeciesSubGroup = "OrdersCreateSubSpeciesSubGroup";
        public const string OrdersDeleteSubSpeciesSubGroup = "OrdersDeleteSubSpeciesSubGroup";

        //SubSpecies age ranges
        public const string OrdersGetAllSubSpeciesAgeRanges = "OrdersGetAllSubSpeciesAgeRanges";
        public const string OrdersGetSubSpeciesAgeRangeById = "OrdersGetSubSpeciesAgeRangeById";
        public const string OrdersCreateSubSpeciesAgeRange = "OrdersCreateSubSpeciesAgeRange";
        public const string OrdersDeleteSubSpeciesAgeRange = "OrdersDeleteSubSpeciesAgeRange";

        //Audit log entries
        public const string OrdersGetAllAuditLogEntries = "OrdersGetAllAuditLogEntries";
        public const string OrdersGetAuditLogEntryById = "OrdersGetAuditLogEntryById";

        //Vets
        public const string OrdersGetAllVets = "OrdersGetAllVets";
        public const string OrdersGetVetById = "OrdersGetVetById";
        public const string OrdersUploadVetSignature = "OrdersUploadVetSignature";
        public const string OrdersGetVetSignature = "OrdersGetVetSignature";
        public const string OrdersDeleteVetSignature = "OrdersDeleteVetSignature";

        //ProductForms
        public const string OrdersGetAllProductForms = "OrdersGetAllProductForms";
        public const string OrdersGetProductFormById = "OrdersGetProductFormById";
        public const string ProductsCreateProductForm = "ProductsCreateProductForm";
        public const string ProductsUpdateProductForm = "ProductsUpdateProductForm";
        public const string ProductsDeleteProductForm = "ProductsDeleteProductForm";
       

        //ProductCategories
        public const string OrdersGetAllProductCategories = "OrdersGetAllProductCategories";
        public const string OrdersGetProductCategoryById = "OrdersGetProductCategoryById";

        //Medication Types
        public const string OrdersGetAllMedicationTypes = "OrdersGetAllMedicationTypes";
        public const string OrdersGetMedicationTypeById = "OrdersGetMedicationTypeById";
        public const string OrdersCreateMedicationType = "CreateMedicationType";
        public const string OrdersUpdateMedicationType = "UpdateMedicationType";

        // Counties
        public const string OrdersGetAllCounties = "OrdersGetAllCounties";
        public const string OrdersGetCountyById = "OrdersGetCountyById";

        // Order VATCodes
        public const string OrdersGetVATCodeById = "OrdersGetVATCodeById";
        public const string OrdersGetAllVATCodes = "OrdersGetAllVATCodes";

        // Order StockControlUnits
        public const string OrdersGetStockControlUnitById = "OrdersGetStockControlUnitById";
        public const string OrdersGetAllStockControlUnits = "OrdersGetAllStockControlUnits";

        //Product Groups
        public const string OrdersGetAllProductGroups = "OrdersGetAllProductGroups";

        //Blocked Orders
        public const string OrdersGetAllBlockedOrders = "OrdersGetAllBlockedOrders";
        public const string OrdersGetAllBlockedOrdersFinancial = "OrdersGetAllBlockedOrdersFinancial";

        //Product Form Price List Adjustments
        public const string OrdersGetProductFormPriceListAdjustments = "OrdersGetProductFormPriceListAdjustments";
        public const string OrdersUpdateProductFormPriceListAdjustments = "OrdersUpdateProductFormPriceListAdjustments";
        public const string OrdersGetProductFormCustomerPriceAdjustment = "OrdersGetProductFormCustomerPriceAdjustment";
        public const string OrdersUpdateProductFormCustomerPriceAdjustment = "OrdersUpdateProductFormCustomerPriceAdjustment";

        // Apply Pending Price Update Processes
        public const string OrdersGetApplyPendingPriceListPricesProcesses = "OrdersGetApplyPendingPriceListPricesProcesses";
        public const string OrdersGetApplyPendingCustomerPricesProcesses = "OrdersGetApplyPendingCustomerPricesProcesses";
        public const string OrdersCreateApplyPendingPriceListPricesProcess = "OrdersCreateApplyPendingPriceListPricesProcess";
        public const string OrdersCreateApplyPendingCustomerPricesProcess = "OrdersCreateApplyPendingCustomerPricesProcess";
        public const string OrdersCreateApplyPendingPricesProcess = "OrdersCreateApplyPendingPricesProcess";
        public const string OrdersGetApplyPendingPricesProcesses = "OrdersGetApplyPendingPricesProcesses";

        public const string OrdersGetAllCustomerPendingPriceUpdateOverride = "OrdersGetAllCustomerPendingPriceUpdateOverride";
        public const string OrdersProductCreateCustomerPendingPriceUpdateOverrides  = "OrdersProductCreateCustomerPendingPriceUpdateOverrides";
        public const string OrdersProductUpdateCustomerPendingPriceUpdateOverrides = "OrdersProductUpdateCustomerPendingPriceUpdateOverrides";
        public const string OrdersProductDeleteCustomerPendingPriceUpdateOverrides = "OrdersProductDeleteCustomerPendingPriceUpdateOverrides";
        public const string OrdersProductCreateCustomerSpecificPricePendingRemoval = "OrdersProductCreateCustomerSpecificPricePendingRemoval";
        public const string OrdersProductCreatePendingCustomerSpecificPriceChange = "OrdersProductCreatePendingCustomerSpecificPriceChange";
        public const string OrdersProductDeletePendingCustomerPricesState = "OrdersProductDeletePendingCustomerPricesState";
        public const string OrdersProductUpdatePendingCustomerPricesRefresh = "OrdersProductUpdatePendingCustomerPricesRefresh";
        public const string OrdersProductDeletePendingPriceListPricesState = "OrdersProductDeletePendingPriceListPricesState";
        public const string OrdersProductCreatePendingPricesCustomerInclusion = "OrdersProductCreatePendingPricesCustomerInclusion";
        public const string OrdersProductDeletePendingPricesCustomerInclusion = "OrdersProductDeletePendingPricesCustomerInclusion";
        public const string OrdersProductCreatePendingPricesPriceListInclusion = "OrdersProductCreatePendingPricesPriceListInclusion";
        public const string OrdersProductDeletePendingPricesPriceListInclusion = "OrdersProductDeletePendingPricesPriceListInclusion";

        public const string OrdersGetAllCustomerPendingPricesConfigurations = "OrdersGetAllCustomerPendingPricesConfigurations";
        public const string OrdersGetAllPriceListPendingPricesConfigurations = "OrdersGetAllPriceListPendingPricesConfigurations";

        public const string OrdersModuleResetPendingPricesModuleState = "OrdersModuleResetPendingPricesModuleState";
        public const string OrdersModuleRefreshPendingPrices = "OrdersModuleRefreshPendingPrices";

        // Delivery Option Price Adjustments
        public const string OrdersDeliveryOptionPriceAdjustments = "OrdersDeliveryOptionPriceAdjustments";
        public const string OrdersUpdateDeliveryOptionPriceAdjustments = "OrdersUpdateDeliveryOptionPriceAdjustments";


        // Prices
        public const string OrdersGetAllCurrentPrices = "OrdersGetAllCurrentPrices";
        public const string OrdersGetAllPendingPrices = "OrdersGetAllPendingPrices";

        #endregion

        #region Transport Route Names
        //Hauliers
        public const string TransportGetAllHauliers = "TransportGetAllHauliers";
        public const string TransportGetHaulierById = "TransportGetHaulierById";
        public const string TransportCreateHaulier = "TransportCreateHaulier";
        public const string TransportUpdateHaulier = "TransportUpdateHaulier";

        //Drivers
        public const string TransportGetAllDrivers = "TransportGetAllDrivers";
        public const string TransportGetDriverById = "TransportGetDriverById";
        public const string TransportCreateDriver = "TransportCreateDriver";
        public const string TransportUpdateDriver = "TransportUpdateDriver";
        public const string TransportDeleteDriver = "TransportDeleteDriver";

        //Trailers
        public const string TransportGetAllTrailersSummary = "TransportGetAllTrailersSummary";
        public const string TransportGetAllTrailers = "TransportGetAllTrailers";
        public const string TransportGetTrailerById = "TransportGetTrailerById";
        public const string TransportCreateTrailer = "TransportCreateTrailer";
        public const string TransportUpdateTrailer = "TransportUpdateTrailer";
        public const string TransportDeleteTrailer = "TransportDeleteTrailer";

        //Vehicles
        public const string TransportGetAllVehicles = "TransportGetAllVehicles";
        public const string TransportGetAllExpandedVehicles = "TransportGetAllExpandedVehicles";
        public const string TransportGetHaulierVehicles = "TransportGetHaulierVehicles";
        public const string TransportGetVehicleById = "TransportGetVehicleById";
        public const string TransportGetExpandedVehicleById = "TransportGetExpandedVehicleById";
        public const string TransportGetHaulierExpandedVehicles = "TransportGetHaulierExpandedVehicles";
        public const string TransportCreateVehicle = "TransportCreateVehicle";
        public const string TransportUpdateVehicle = "TransportUpdateVehicle";
        public const string TransportDeleteVehicle = "TransportDeleteVehicle";
        public const string TransportGetAllVehicleTypes = "TransportGetAllVehicleTypes";
        public const string TransportGetVehicleTypeById = "TransportGetVehicleTypeById";

        //OrderLines
        public const string TransportGetAllOrderLines = "TransportGetAllOrderLines";

        //Loads
        public const string TransportGetAllLoadsSummary = "TransportGetAllLoadsSummary";
        public const string TransportGetAllLoads = "TransportGetAllLoads";
        public const string TransportCreateLoad = "TransportCreateLoad";
        public const string TransportChangeLoadStatus = "TransportChangeLoadStatus";
        public const string TransportBulkLoadStatus = "TransportBulkLoadStatus";
        public const string TransportUpdateLoad = "TransportUpdateLoad";
        public const string TransportGetLoadById = "TransportGetLoadById";
        public const string TransportAddOrderLinesToLoad = "TransportAddOrderLinesToLoad";
        public const string TransportRemoveOrderLineFromLoad = "TransportRemoveOrderLineFromLoad";
        public const string TransportRemoveOrderLineFromLoadOld = "TransportRemoveOrderLineFromLoadOld";

        //Load sections
        public const string TransportUpdateLoadSectionCollectionArea = "TransportUpdateLoadSectionCollectionArea";

        //Acknowledgements
        public const string TransportCreateAcknowledgement = "TransportCreateAcknowledgement";

        //OrderLine notes
        public const string TransportGetAllOrderLineNotes = "TransportGetAllOrderLineNotes";
        public const string TransportGetAllOrderLineGroupedNotes = "TransportGetAllOrderLineGroupedNotes";

        //Mills
        public const string OrderGetAllMills = "OrderGetAllMills";
        public const string OrderGetMillById = "OrderGetMillById";
        public const string OrderCreateMill = "OrderCreateMill";
        public const string OrderUpdateMill = "OrderUpdateMill";
        public const string OrderDeleteMill = "OrderDeleteMill";

        //Collection areas
        public const string TransportGetAllCollectionAreas = "TransportGetAllCollectionAreas";
        public const string TransportGetCollectionAreaById = "TransportGetCollectionAreaById";

        //Haulage Rate
        public const string TransportGetAllHaulageRates = "TransportGetAllHaulageRates";
        public const string TransportGetHaulageRateById = "TransportGetHaulageRateById";
        public const string TransportCreateHaulageRate = "TransportCreateHaulageRate";
        public const string TransportUpdateHaulageRate = "TransportUpdateHaulageRate";
        public const string TransportDeleteHaulageRate = "TransportDeleteHaulageRate";

        #endregion

        #region RawMaterials

        public const string RawMaterialsGetStoreById = "RawMaterialsGetStoreById";
        public const string RawMaterialsGetAllStores = "RawMaterialsGetAllStores";
        public const string RawMaterialsCreateStore = "RawMaterialsCreateStore";
        public const string RawMaterialsUpdateStore = "RawMaterialsUpdateStore";
        public const string RawMaterialsGetAllLocations = "RawMaterialsGetAllLocations";
        public const string RawMaterialsGetAllSupplierStoreAuditsBySupplierId = "RawMaterialsGetAllSupplierStoreAuditsBySupplierId";
        public const string RawMaterialsCreateSupplierStoreAudit = "RawMaterialsCreateSupplierStoreAudit";
        public const string RawMaterialsGetAllSupplierPerformanceRecords = "RawMaterialsGetAllSupplierPerformanceRecords";
        public const string RawMaterialsCreateSupplierPerformanceRecord = "RawMaterialsCreateSupplierPerformanceRecord";
        public const string RawMaterialsGetRawMaterialById = "RawMaterialsGetRawMaterialById";
        public const string RawMaterialsGetAllRawMaterials = "RawMaterialsGetAllRawMaterials";
        public const string RawMaterialsCreateRawMaterial = "RawMaterialsCreateRawMaterial";
        public const string RawMaterialsUpdateRawMaterial = "RawMaterialsUpdateRawMaterial";
        public const string RawMaterialsDeleteRawMaterial = "RawMaterialsDeleteRawMaterial";
        public const string RawMaterialsGetAllSupplierApprovedMaterials = "RawMaterialsGetAllSupplierApprovedMaterials";
        public const string RawMaterialsCreateSupplierApprovedMaterial = "RawMaterialsCreateSupplierApprovedMaterial";
        public const string RawMaterialsDeleteSupplierApprovedMaterial = "RawMaterialsDeleteSupplierApprovedMaterial";

        public const string RawMaterialsGetAllContracts = "RawMaterialsGetAllContracts";
        public const string RawMaterialsGetContractById = "RawMaterialsGetContractById";
        public const string RawMaterialsCreateContract = "RawMaterialsCreateContract";
        public const string RawMaterialsUpdateContract = "RawMaterialsUpdateContract";
        public const string RawMaterialsUpdateContractMonthlySupply = "RawMaterialsUpdateContractMonthlySupply";
        public const string RawMaterialsGetAllContractTransactions = "RawMaterialsGetAllContractTransactions";
        public const string RawMaterialsGetContractTransactionById = "RawMaterialsGetContractTransactionById";
        public const string RawMaterialsRejectContractTransaction = "RawMaterialsRejectContractTransaction";
        public const string RawMaterialsUpdateNonDocketContractTransaction = "RawMaterialsUpdateNonDocketContractTransaction";
        public const string RawMaterialsUpdateDocketContractTransaction = "RawMaterialsUpdateDocketContractTransaction";
        public const string RawMaterialsUpdateContractTransactionSequenceNumber = "RawMaterialsUpdateContractTransactionSequenceNumber";
        public const string RawMaterialsTransferContractTransaction = "RawMaterialsTransferContractTransaction";
        public const string RawMaterialsGetAllRawMaterialOrders = "RawMaterialsGetAllRawMaterialOrders";
        public const string RawMaterialsGetRawMaterialOrderById = "RawMaterialsGetRawMaterialOrderById";
        public const string RawMaterialsGetAllRawMaterialOrderLine = "RawMaterialsGetAllRawMaterialOrderLine";
        public const string RawMaterialsCreateRawMaterialOrder = "RawMaterialsCreateRawMaterialOrder";
        public const string RawMaterialsGetAllCollectionOrders = "RawMaterialsGetAllCollectionOrders";
        public const string RawMaterialsGetCollectionOrderById = "RawMaterialsGetCollectionOrderById";
        public const string RawMaterialsCancelCollectionOrder = "RawMaterialsCancelCollectionOrder";
        public const string RawMaterialsCollectionOrderContractAllocation = "RawMaterialsCollectionOrderContractAllocation";
        public const string RawMaterialsCreateCollectionOrders = "RawMaterialsCreateCollectionOrders";
        public const string RawMaterialsUpdateCollectionOrder = "RawMaterialsUpdateCollectionOrder";

        public const string RawMaterialsDeleteCollectionOrder = "RawMaterialsDeleteCollectionOrder";

        public const string RawMaterialsCreateWeighment = "RawMaterialsCreateWeighment";
        public const string RawMaterialsWeighOutARawMaterialWeighment = "RawMaterialsWeighOutARawMaterialWeighment";
        public const string RawMaterialsCancelRawMaterialWeighment = "RawMaterialsCancelRawMaterialWeighment";
        public const string RawMaterialsGetAllRawMaterialWeighments = "RawMaterialsGetAllRawMaterialWeighments";
        public const string RawMaterialsUpdateRawMaterialWeighment = "RawMaterialsUpdateRawMaterialWeighment";
        public const string RawMaterialsGetRawMaterialWeighmentById = "RawMaterialsGetRawMaterialWeighmentById";
        public const string RawMaterialsGetCollectionOrderDocumentById = "RawMaterialsGetCollectionOrderDocumentById";
        public const string RawMaterialsGetDocketDocumentById = "RawMaterialsGetDocketDocumentById";

        public const string RawMaterialsGetAllSuppliers = "RawMaterialsGetAllSuppliers";
        public const string RawMaterialsGetSupplierById = "RawMaterialsGetSupplierById";
        public const string RawMaterialsCreateSupplier = "RawMaterialsCreateSupplier";
        public const string RawMaterialsUpdateSupplier = "RawMaterialsUpdateSupplier";
        public const string RawMaterialsGetGetContractSupplyByMonth = "RawMaterialsGetGetContractSupplyByMonth";
        public const string RawMaterialsGetGetContractWeeklySupply = "RawMaterialsGetGetContractWeeklySupply";
        public const string RawMaterialsCollectionOrderArchivalProcessCommand = "RawMaterialsCollectionOrderArchivalProcessCommand";

        public const string RawMaterialsUpdateContractWeeklySupply = "RawMaterialsUpdateContractWeeklySupply";

        public const string RawMaterialsUpdateCollectionOrderStatusCommand = "RawMaterialsUpdateCollectionOrderStatusCommand";

        public const string RawMaterialGetDocketDocumentById = "RawMaterialGetDocketDocumentById";
        public const string RawMaterialDocketGetDocketDocumentById = "RawMaterialDocketGetDocketDocumentById";
        public const string RawMaterialGetDriverByIdCode = "RawMaterialGetDriverByIdCode";

        public const string RawMaterialsCreateContractTransactions = "RawMaterialsCreateContractTransactions";

        public const string RawMaterialsGetAllHaulageRates = "RawMaterialsGetAllHaulageRates";
        public const string RawMaterialsGetHaulageRateById = "RawMaterialsGetHaulageRateById";
        public const string RawMaterialsCreateHaulageRate = "RawMaterialsCreateHaulageRate";
        public const string RawMaterialsUpdateHaulageRate = "RawMaterialsUpdateHaulageRate";
        public const string RawMaterialsDeleteHaulageRate = "RawMaterialsDeleteHaulageRate";

        public const string RawMaterialsDriverTerminalGetAllCollectionOrders = "RawMaterialsDriverTerminalGetAllCollectionOrders";
        public const string RawMaterialsDriversTerminalGetAllRawMaterialWeighments = "RawMaterialsDriversTerminalGetAllRawMaterialWeighments";
        public const string RawMaterialsDeleteStore = "RawMaterialsDeleteStore";
        public const string RawMaterialsDriverTerminalGetRawMaterialWeighmentById = "RawMaterialsDriverTerminalGetRawMaterialWeighmentById";
        public const string RawMaterialsDriverTerminalUpdateCollectionOrderStatus = "RawMaterialsDriverTerminalUpdateCollectionOrderStatus";
        public const string RawMaterialsDriverTerminalGetAllDockets = "RawMaterialsDriverTerminalGetAllDockets";

        #endregion

        #region Loading Route Names
        public const string LoadingGetAllLoadMaterialTypes = "LoadingGetAllLoadMaterialTypes";
        public const string LoadingGetLoadMaterialTypeById = "LoadingGetLoadMaterialTypeById";
        public const string LoadingCreateLoadMaterialType = "LoadingCreateLoadMaterialType";
        public const string LoadingUpdateLoadMaterialType = "LoadingUpdateLoadMaterialType";
        public const string LoadingDeleteLoadMaterialType = "LoadingDeleteLoadMaterialType";


        public const string LoadingGetAllCollectionAreas = "LoadingGetAllCollectionAreas";
        public const string LoadingGetCollectionAreaById = "LoadingGetCollectionAreaById";
        public const string LoadingCreateLoadRequest = "LoadingCreateLoadRequest";

        public const string LoadingGetProductConfigurationByCode = "LoadingGetProductConfigurationByCode";

        public const string LoadingGetAllLoads = "LoadingGetAllLoads";
        public const string LoadingGetDriverLoads = "LoadingGetDriverLoads";
        public const string LoadingGetLoadById = "LoadingGetLoadById";
        public const string LoadingReorderLoadSections = "LoadingReorderLoadSections";
        public const string LoadingGetAllOrderLines = "LoadingGetAllOrderLines";
        public const string LoadingChangeSectionPreparationStatus = "LoadingChangeSectionPreparationStatus";
        public const string LoadingChangeLoadingStatus = "LoadingChangeLoadingStatus";
        public const string LoadingReassignOrderLinesSections = "LoadingReassignOrderLinesSections";

        //Acknowledgements
        public const string LoadingCreateAcknowledgement = "LoadingCreateAcknowledgement";
        public const string LoadingAddVehicleTypeToLoad = "LoadingAddVehicleTypeToLoad";

        //Loading Orderline notes
        public const string LoadingGetAllLoadOrderLineNotes = "LoadingGetAllLoadOrderLineNotes";
        public const string LoadingGetAllLoadOrderLineGroupedNotes = "LoadingGetAllLoadOrderLineGroupedNotes";

        //Loadign notes
        public const string LoadingGetAllLoadNotes = "LoadingGetAllLoadNotes";
        public const string LoadingGetAllLoadGroupedNotes = "LoadingGetAllLoadGroupedNotes";

        //Delivery Dockets
        public const string DeliveryGetAllDockets = "DeliveryGetAllDockets";
        public const string DeliveryGetDocketById = "DeliveryGetDocketById";

        //Loaded Order lines
        public const string LoadingGetAllLoadedOrderLines = "LoadingGetAllLoadedOrderLines";
        public const string LoadingGetLoadedOrderLineById = "LoadingGetLoadedOrderLineById";
        public const string LoadingLoadOrderLines = "LoadingLoadOrderLines";

        //Completed Load Requests
        public const string LoadingCreateCompletedLoadRequestItem = "LoadingCreateCompletedLoadRequestItem";

        public const string LoadingGetLoadWeighmentsById = "LoadingGetLoadWeighmentsById";
        public const string LoadingCreateLoadOrderLineWeighment = "LoadingCreateLoadOrderLineWeighment";
        public const string LoadingGetLoadOrderLineWeighmentById = "LoadingGetLoadOrderLineWeighmentById";
        public const string LoadingUpdateSecondWeighment = "LoadingUpdateSecondWeighment";
        public const string LoadingUpdateFirstWeighment = "LoadingUpdateFirstWeighment";
        public const string LoadingUpdateWeightmentBinAndRunNumbers = "LoadingUpdateWeightmentBinAndRunNumbers";

        #endregion

        #region Formulations Route Names

        public const string FormulationsGetAllRawMaterials = "FormulationsGetAllRawMaterials";
        public const string FormulationsGetSingleRawMaterial = "FormulationsGetSingleRawMaterial";
        public const string FormulationsUpdateRawMaterial = "FormulationsUpdateRawMaterial";
        public const string FormulationsGetRawMaterialFootnotes = "FormulationsGetRawMaterialFootnotes";
        public const string FormulationsGetRawMaterialFootnoteById = "FormulationsGetRawMaterialFootnoteById";
        public const string FormulationsCreateRawMaterialFootnote = "FormulationsCreateRawMaterialFootnote";
        public const string FormulationsRemoveRawMaterialFootnote = "FormulationsRemoveRawMaterialFootnote";
        public const string FormulationsGetAllNutritionalValues = "FormulationsGetAllNutritionalValues";
        public const string FormulationsGetSingleNutritionalValue = "FormulationsGetSingleNutritionalValue";
        public const string FormulationsCreateNutritionalValue = "FormulationsCreateNutritionalValue";
        public const string FormulationsUpdateNutritionalValue = "FormulationsUpdateNutritionalValue";
        public const string FormulationsGetAllUnitsOfMeasure = "FormulationsGetAllUnitsOfMeasure";
        public const string FormulationsGetAllFootnotes = "FormulationsGetAllFootnotes";
        public const string FormulationsGetAllFormulations = "FormulationsGetAllFormulations";
        public const string FormulationsGetSingleFormulation = "FormulationsGetSingleFormulation";
        public const string FormulationsGetAllFormulationNutritionalValues = "FormulationsGetAllFormulationNutritionalValues";
        public const string FormulationsGetSingleFormulationNutritionalValue = "FormulationsGetSingleFormulationNutritionalValue";
        public const string FormulationsGetAllLabellingMaterials = "FormulationsGetAllLabellingMaterials";
        public const string FormulationsGetSingleLabellingMaterial = "FormulationsGetSingleLabellingMaterial";
        public const string FormulationsGetAllIngredients = "FormulationsGetAllIngredients";
        public const string FormulationsGetSingleIngredient = "FormulationsGetSingleIngredient";
        public const string FormulationsUpdateLabellingMaterialsPrintOrder = "FormulationsUpdateLabellingMaterialsPrintOrder";
        public const string FormulationsUpdateFormulationNutritionalValuesPrintOrder = "FormulationsUpdateFormulationNutritionalValuesPrintOrder";
        public const string FormulationsCreateFormulation = "FormulationsCreateFormulation";
        public const string FormulationsCreateFormulationNutritionalValue = "FormulationsCreateFormulationNutritionalValue";
        public const string FormulationsUpdateFormulationNutritionalValue = "FormulationsUpdateFormulationNutritionalValue";
        public const string FormulationsCreateLabellingMaterial = "FormulationsCreateLabellingMaterial";
        public const string FormulationsUpdateLabellingMaterial = "FormulationsUpdateLabellingMaterial";
        public const string FormulationsUpdateFormulation = "FormulationsUpdateFormulation";
        public const string FormulationsApproveFormulation = "FormulationsApproveFormulation";
        public const string FormulationsCreateIngredient = "FormulationsCreateIngredient";
        public const string FormulationsUpdateIngredient = "FormulationsUpdateIngredient";
        public const string FormulationsRemoveIngredient = "FormulationsRemoveIngredient";
        public const string FormulationsRemoveLabellingMaterial = "FormulationsRemoveLabellingMaterial";
        public const string FormulationsRemoveNutritionalValue = "FormulationsRemoveNutritionalValue";
        public const string FormulationsCreateFormulationImportProcess = "FormulationsCreateFormulationImportProcess";
        public const string FormulationsGetAllFormulationImportProcesses = "FormulationsGetAllFormulationImportProcesses";

        #endregion

        #region Delivery Route Names

        //Deliveries
        public const string DeliveryGetAllDeliveries = "DeliveryGetAllDeliveries";
        public const string DeliveryGetDeliveryById = "DeliveryGetDeliveryById";
        public const string DeliveryGetDriverDeliveries = "DeliveryGetDriverDeliveries";
        public const string DeliveryUploadDeliveryDocketDocument = "DeliveryUploadDeliveryDocketDocument";
        public const string DeliveryCreateDeliveryVehicleLocationUpdate = "DeliveryCreateDeliveryVehicleLocationUpdate";
        public const string DeliveryCompleteDocketDelivery = "DeliveryCompleteDocketDelivery";
        public const string DeliveryExcludeDocketFromInvoicing = "DeliveryExcludeDocketFromInvoicing";
        public const string DeliveryUpdateDocketHaulageReportStatusAsync = "UpdateDocketHaulageReportStatus";

        public const string DeliveryGetAllDocketItems = "DeliveryGetAllDocketItems";
        public const string DeliveryGetDocketItemMedicationDetailsById = "DeliveryGetDocketItemMedicationDetailsById";
        public const string DeliveryGetDeliveryDocketItems = "DeliveryGetDeliveryDocketItems";
        public const string DeliveryGetVehicleLocationForDelivery = "DeliveryGetVehicleLocationForDelivery";

        #endregion

        #region Billing Route Names

        public const string BillingGetInvoicingConfiguration = "BillingGetInvoicingConfiguration";
        public const string BillingUpdateInvoicingConfiguration = "BillingUpdateInvoicingConfiguration";
        public const string BillingGetAllMedications = "BillingGetAllMedications";
        public const string BillingGetMedicationById = "BillingGetMedicationById";
        public const string BillingGetVATCodeById = "BillingGetVATCodeById";
        public const string BillingGetAllVATCodes = "BillingGetAllVATCodes";
        public const string BillingGetAllHauliers = "BillingGetAllHauliers";
        public const string BillingGetHaulierById = "BillingGetHaulierById";

        public const string BillingGetAllBillingDocuments = "BillingGetAllBillingDocuments";
        public const string BillingGetBillingDocumentById = "BillingGetBillingDocumentById";
        public const string BillingGetAllBillingDocumentItems = "BillingGetAllBillingDocumentItems";
        public const string BillingGetBillingDocumentItemById = "BillingGetBillingDocumentItemById";
        public const string BillingCreateBillingDocument = "BillingCreateBillingDocument";
        public const string BillingUploadBillingDocumentFile = "BillingUploadBillingDocumentFile";

        public const string BillingGetProductConfigurationById = "BillingGetProductConfigurationById";
        public const string BillingGetProductConfigurations = "BillingGetProductConfigurations";

        public const string BillingGetAllBillingReasons = "BillingGetAllBillingReasons";
        public const string BillingGetBillingReasonsById = "BillingGetBillingReasonsById";
        public const string BillingCreateBillingReason = "BillingCreateBillingReason";
        public const string BillingUpdateBillingReason = "BillingUpdateBillingReason";
        public const string BillingDeleteBillingReason = "BillingDeleteBillingReason";

        public const string BillingGetAllExchangeRates = "BillingGetAllExchangeRates";
        public const string BillingCreateExchangeRate = "BillingCreateExchangeRate";
        public const string BillingUpdateExchangeRate = "BillingUpdateExchangeRate";

        public const string BillingGetAllPalletPrices = "BillingGetAllPalletPrices";
        public const string BillingUpdatePalletPrice = "BillingUpdatePalletPrice";

        public const string BillingGetAllPalletAccountTransactions = "BillingGetAllPalletAccountTransactions";
        public const string BillingGetPalletAccountTransactionForAccountById = "BillingGetPalletAccountTransactionForAccountById";
        public const string BillingGetPalletAccountTransactionById = "BillingGetPalletAccountTransactionById";
        public const string BillingCreatePalletAccountTransaction = "BillingCreatePalletAccountTransaction";
        public const string BillingGetPalletTransactionBillingDocumentStatus = "BillingGetPalletTransactionBillingDocumentStatus";

        #endregion

        #region BagLabelling Route Names

        public const string BagLabellingGetAllLabelTemplates = "BagLabellingGetAllLabelTemplates";
        public const string BagLabellingCreateBagLabel = "BagLabellingCreateBagLabel";
        public const string BagLabellingValidateBagLabel = "BagLabellingValidateBagLabel";

        #endregion

        #region Rbac Route Names

        public const string RbacGetAuthenticatedUserApplicationPermissions = "RbacGetAuthenticatedUserApplicationPermissions";
        public const string RbacAddApplicationPermissionToRole = "RbacAddApplicationPermissionToRole";
        public const string RbacRemoveApplicationPermissionFromRole = "RbacRemoveApplicationPermissionFromRole";
        public const string RbacGetRoleMembers = "RbacGetRoleMembers";
        public const string RbacGetRolePermissions = "RbacGetRolePermissions";
        public const string RbacCreateRole = "RbacCreateRole";
        public const string RbacAddUserToRole = "RbacAddUserToRole";
        public const string RbacRemoveUserFromRole = "RbacRemoveUserFromRole";
        public const string RbacUpdateRole = "RbacUpdateRole";
        public const string RbacRemoveRole = "RbacRemoveRole";

        #endregion

        #region Notifications Route Names
        // Contacts
        public const string NotificationsGetContacts = "NotificationsGetContacts";
        public const string AddNotifications = "AddNotifications";

        #endregion

        #region Print Route Names

        public const string PrintGetDocumentToPrint = "PrintGetDocumentToPrint";
        public const string PrintUploadDocumentToPrint = "PrintUploadDocumentToPrint";
        public const string PrintUpdatePrintedDocumentStatus = "PrintUpdatePrintedDocumentStatus";

        #endregion

        #region Auditing Route Names

        public const string AuditingGetAuditLogEntries = "AuditingGetAuditLogEntries";

        #endregion

        #region Application Configuration Route Names

        public const string VculpUiApplicationConfiguration = "VculpUiApplicationConfiguration";

        #endregion
    }
}
