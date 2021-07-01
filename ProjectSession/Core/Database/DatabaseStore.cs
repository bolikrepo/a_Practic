using System;
using ProjectSession;
using ProjectSession.RealEstateAgencyDataSetTableAdapters;

namespace DatabaseStore
{
    public static class DataTablesStore
    {
        public static RealEstateAgencyDataSet Database { get; } = new RealEstateAgencyDataSet();

        #region TABLE MANAGER
        public static TableAdapterManager AdapterManager { get; } = new TableAdapterManager();
        public static void UpdateAll() => AdapterManager.UpdateAll(Database);
        #endregion

        static DataTablesStore()
        {
            // Data Source=192.168.1.53,1433;Initial Catalog=RealEstateAgency;Persist Security Info=True;User ID=SA;Password=Wka4napb123321
            // Data Source=DESKTOP-OMLO9KT;Initial Catalog=RealEstateAgency;Integrated Security=True

            try{
                #region HOME
                var agents = new Agents_ViewTableAdapter();
                Agents = new DatabaseAdapterPair
                    ("Agents_View", agents.Connection, agents.Adapter, Database.Agents_View);

                var clients = new Clients_ViewTableAdapter();
                Clients = new DatabaseAdapterPair
                    ("Clients_View", clients.Connection, clients.Adapter, Database.Clients_View);
                #endregion

                #region REALESTATE
                var apartment = new RES_Apartment_ViewTableAdapter();
                Apartment = new DatabaseAdapterPair
                    ("RES_Apartment_View", apartment.Connection, apartment.Adapter, Database.RES_Apartment_View);

                var house = new RES_House_ViewTableAdapter();
                House = new DatabaseAdapterPair
                    ("RES_House_View", house.Connection, house.Adapter, Database.RES_House_View);

                var land = new RES_Land_ViewTableAdapter();
                Land = new DatabaseAdapterPair
                    ("RES_Land_View", land.Connection, land.Adapter, Database.RES_Land_View);

                #endregion

                #region REALESTATE FILTER

                var apartment_filter = new FL_Apartment_ViewTableAdapter();
                ApartmentFilter = new DatabaseAdapterPair
                    ("FL_Apartment_View", apartment_filter.Connection, apartment_filter.Adapter, Database.FL_Apartment_View);

                var house_filter = new FL_House_ViewTableAdapter();
                HouseFilter = new DatabaseAdapterPair
                    ("FL_House_View", house_filter.Connection, house_filter.Adapter, Database.FL_House_View);

                var land_filter = new FL_Land_ViewTableAdapter();
                LandFilter = new DatabaseAdapterPair
                    ("FL_Land_View", land_filter.Connection, land_filter.Adapter, Database.FL_Land_View);

                #endregion

                #region TRANSACTIONS

                var demands = new DemandSetTableAdapter();
                Demands = new DatabaseAdapterPair
                    ("DemandSet", demands.Connection, demands.Adapter, Database.DemandSet);

                var deals = new DealSetTableAdapter();
                Deals = new DatabaseAdapterPair
                    ("DealSet", deals.Connection, deals.Adapter, Database.DealSet);

                var supplies = new SupplySetTableAdapter();
                Supplies = new DatabaseAdapterPair
                    ("SupplySet", supplies.Connection, supplies.Adapter, Database.SupplySet);


                #endregion

                #region SIDE EFFECT

                var fk_agents = new Agents_FK_PreviewTableAdapter();
                FK_Agents = new DatabaseAdapterPair
                    ("Agents_FK_Preview", fk_agents.Connection, fk_agents.Adapter, Database.Agents_FK_Preview);

                var fk_clients = new Clients_FK_PreviewTableAdapter();
                FK_Clients = new DatabaseAdapterPair
                    ("Clients_FK_Preview", fk_clients.Connection, fk_clients.Adapter, Database.Clients_FK_Preview);

                var fk_real_estate = new RealEstateSet_FK_PreviewTableAdapter();
                FK_RealEstate = new DatabaseAdapterPair
                    ("RealEstateSet_FK_Preview", fk_real_estate.Connection, fk_real_estate.Adapter, Database.RealEstateSet_FK_Preview);

                var fk_real_estate_filter = new RealEstateFilterSet_FK_PreviewTableAdapter();
                FK_RealEstateFilter = new DatabaseAdapterPair
                    ("RealEstateFilterSet_FK_Preview", fk_real_estate_filter.Connection, fk_real_estate_filter.Adapter, Database.RealEstateFilterSet_FK_Preview);

                #endregion

            }catch{ throw new ApplicationException("Невозможно подключиться к Базе Данных."); }
        }

        public static DatabaseAdapterPair Agents { get; private set; }
        public static DatabaseAdapterPair Clients { get; private set; }

        public static DatabaseAdapterPair Apartment { get; private set; }
        public static DatabaseAdapterPair House { get; private set; }
        public static DatabaseAdapterPair Land { get; private set; }

        public static DatabaseAdapterPair ApartmentFilter { get; private set; }
        public static DatabaseAdapterPair HouseFilter { get; private set; }
        public static DatabaseAdapterPair LandFilter { get; private set; }

        /// <summary>
        /// Сделки (DealsSet)
        /// <para> FK Demand ID (Demand_Id) </para>
        /// <para> FK Supply ID (Supply_Id) </para>
        /// </summary>
        public static DatabaseAdapterPair Deals { get; private set; }

        /// <summary>
        /// Потребности
        /// <para> FK PersonSet Client ID (Agent_Id) </para>
        /// <para> FK PersonSet Agent ID (Client_Id) </para>
        /// <para> FK RealEstateFilter ID (RealEstateFilter_Id) </para>
        /// </summary>
        public static DatabaseAdapterPair Demands { get; private set; }

        /// <summary>
        /// Предложения
        /// <para> FK PersonSet Client ID (Agent_Id) </para>
        /// <para> FK PersonSet Agent ID (Client_Id) </para>
        /// <para> FK RealEstate ID (RealEstate_Id) </para>
        /// </summary>
        public static DatabaseAdapterPair Supplies { get; private set; }

        public static DatabaseAdapterPair FK_Agents { get; private set; }
        public static DatabaseAdapterPair FK_Clients { get; private set; }
        public static DatabaseAdapterPair FK_RealEstate { get; private set; }
        public static DatabaseAdapterPair FK_RealEstateFilter { get; private set; }

    }
}
