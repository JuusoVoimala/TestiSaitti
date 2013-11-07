﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ilmoittaudu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnIlmoittaudu_Click(object sender, EventArgs e)
    {
        //Luodaan kontekstiin uusi entiteetti ja päivitetään muutos kantaan
        if (txtAsioid.Text.Length * txtEtunimi.Text.Length * txtSukunimi.Text.Length > 0)
        {
            //Luodaan uusi entiteetti
            DemoxOyEntities ctx = new DemoxOyEntities();
            lasnaolot lasnaolo = new lasnaolot();
            lasnaolo.asioid = txtAsioid.Text;
            lasnaolo.course = "IIO13200";
            lasnaolo.firstname = txtEtunimi.Text;
            lasnaolo.lastname = txtSukunimi.Text;
            lasnaolo.date = DateTime.Now;    //new DateTime(2013, 10, 10);
            //Lisätään se kontekstiin
            ctx.lasnaolots.Add(lasnaolo);
            //tallennus kantaan
            ctx.SaveChanges();
        }
    }
}