﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividueleOpdrachtSE2
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        private List<Product> gevondenProducten;
        private List<Shop> gevondenShops;

        protected void Page_Load(object sender, EventArgs e)
        {
            string zoekString = Request.QueryString["zoek"];
            if (zoekString != null && zoekString != "")
            {
                gevondenProducten = VerkrijgProducten(zoekString);
                gevondenShops = VerkrijgShops(zoekString);

                if (gevondenProducten != null && gevondenProducten.Count != 0)
                {
                    lvwProducten.DataSource = gevondenProducten;
                    lvwProducten.DataBind();
                }
                else
                {
                    divGevondenProducten.InnerHtml = "<b>Geen producten Gevonden</b>";
                }

                if (gevondenShops != null && gevondenShops.Count != 0)
                {
                    lvwShops.DataSource = gevondenShops;
                    lvwShops.DataBind();
                }
                else
                {
                    divGevondenShops.InnerHtml = "<b>Geen shops Gevonden</b>";
                }
            }
            else
            {
                divGevondenProducten.InnerHtml = "<b>Geen zoekterm ingevuld!</b>";
                divGevondenShops.InnerHtml = "<b>Geen zoekterm ingevuld!</b>";
            }
        }

        private List<Product> VerkrijgProducten(string zoekString)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgProducten(zoekString);
        }

        private List<Shop> VerkrijgShops(string zoekString)
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgShops(zoekString);
        }
    }
}