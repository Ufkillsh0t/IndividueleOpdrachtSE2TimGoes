﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividueleOpdrachtSE2
{
    public class Product
    {
        public int ID { get; set; }

        public Productgroep ProductGroep { get; set; }

        public string EANcode { get; set; }

        public string Code { get; set; }

        //minprijs

        //avgprijs

        public string Naam { get; set; }

        public string Merk { get; set; }

        public DateTime TestDatum { get; set; }

        public string Plaatje { get; set; }

        public string FabrikantSite { get; set; }

        public List<Specificatie> Specificaties { get; set; }

        public Product(int id, string naam, string merk, DateTime TestDatum)
        {
            this.ID = id;
            this.Naam = naam;
            this.Merk = merk;
            this.TestDatum = TestDatum;
        }

        public Product(int id, Productgroep productGroep, string EANcode, string code, string naam, string merk, DateTime TestDatum, string plaatje, string fabrikantSite)
        {
            this.ID = id;
            this.ProductGroep = productGroep;
            this.EANcode = EANcode;
            this.Code = code;
            this.Naam = naam;
            this.Merk = merk;
            this.TestDatum = TestDatum;
            this.Plaatje = plaatje;
            this.FabrikantSite = fabrikantSite;

            this.Specificaties = VerkrijgSpecificaties();
        }

        private List<Specificatie> VerkrijgSpecificaties()
        {
            DatabaseManager dm = new DatabaseManager();
            return dm.VerkrijgSpecificaties(this.ID);
        }
    }
}