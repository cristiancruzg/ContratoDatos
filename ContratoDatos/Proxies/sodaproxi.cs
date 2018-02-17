using ContratoDatos.Models;
using SODA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContratoDatos.Proxies
{
    public class sodaproxi : IDisposable
    {
        #region campos
        private SodaClient client;
        private const string ID_DATASET = "q9x7-8rta";
        private const string URL_PORTAL = "https://www.datos.gov.co";
        private const string APP_TOKEN = "vQVbqyXCgQ04n0fYvzyqIzmw6";
        private const string USUARIO = "crisjalds@gmail.com";
        private const string CLAVE = "MiSena2017*";

        #endregion
        #region construir/destruir
        public sodaproxi()
        {
            client = new SodaClient(URL_PORTAL, APP_TOKEN, USUARIO, CLAVE);
        }
        public void Dispose()
        {
            if (client != null)

                client = null;
        }
        #endregion
        public IEnumerable<datos> ObtenerParaderos()
        {
            var dataset = client.GetResource<datos>(ID_DATASET);
            return dataset.GetRows();
        }
        //public  datos ObtenerDatos(int datoId)
        //{


        //}
    }

}
