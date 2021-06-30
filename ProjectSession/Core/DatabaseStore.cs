using ProjectSession;
using ProjectSession.RealEstateAgencyDataSetTableAdapters;
using System;
using ProjectSession.Core;

namespace DatabaseStore
{
    public static class DatatablesStore
    {
        public static RealEstateAgencyDataSet Database { get; } = new RealEstateAgencyDataSet();

        #region TABLE MANAGER
        public static TableAdapterManager AdapterManager { get; } = new TableAdapterManager();
        public static void UpdateAll() => AdapterManager.UpdateAll(Database);
        #endregion

        static DatatablesStore()
        {
            try
            {
                var agents = new Agents_ViewTableAdapter();
                Agents = new DatabaseAdapterPair
                    ("Agents_View", agents.Connection, agents.Adapter, Database.Agents_View);

                var clients = new Clients_ViewTableAdapter();
                Clients = new DatabaseAdapterPair
                    ("Clients_View", clients.Connection, clients.Adapter, Database.Clients_View);

                var apartment = new RES_Apartment_ViewTableAdapter();
                Apartment = new DatabaseAdapterPair
                    ("RES_Apartment_View", apartment.Connection, apartment.Adapter, Database.RES_Apartment_View);

                var house = new RES_House_ViewTableAdapter();
                House = new DatabaseAdapterPair
                    ("RES_House_View", house.Connection, house.Adapter, Database.RES_House_View);

                var land = new RES_Land_ViewTableAdapter();
                Land = new DatabaseAdapterPair
                    ("RES_Land_View", land.Connection, land.Adapter, Database.RES_Land_View);

                var supplySet = new SupplySetTableAdapter();
                SupplySet = new DatabaseAdapterPair
                    ("SupplySet", supplySet.Connection, supplySet.Adapter, Database.SupplySet);
            }
            catch
            {
                MessageManager.showError("Ошибка подключения", "невозможно подключиться к серверу");
            }
        }

        public static DatabaseAdapterPair Agents { get; private set; }
        public static DatabaseAdapterPair Clients { get; private set; }

        public static DatabaseAdapterPair Apartment { get; private set; }
        public static DatabaseAdapterPair House { get; private set; }
        public static DatabaseAdapterPair Land { get; private set; }
        public static DatabaseAdapterPair SupplySet { get; private set; }



    }
}
