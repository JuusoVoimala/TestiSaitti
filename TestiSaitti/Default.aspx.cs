using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DemoxOyEntities ctx;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //populoidaan dropdownlist ja muut tarvittavat kontrollit
            ctx = new DemoxOyEntities();
            var opiskelijat = (from lo in ctx.lasnaolots
                               where lo.course.StartsWith("IIO13200")
                               orderby lo.asioid
                               select lo.asioid).Distinct();
            ddlStudents.DataSource = opiskelijat.ToList();
            ddlStudents.DataBind(); // KOKEESSA OSATTAVA TEHDÄ TÄMÄ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }
    protected void btnGetIlmos_Click(object sender, EventArgs e)
    {
        //Haetaan ilmottautumiset EF:n avulla
        ctx = new DemoxOyEntities();
        //Kysely tuo kaiken tiedon entiteeteistä
        //var kysely = from lo in ctx.lasnaolots
        //             where lo.course.Contains("IIO13200")
        //             select lo;
        //Kysely jolla haetaan asioid, sukunumi, etunimi ja pvm
        var kysely = from lo in ctx.lasnaolots
                     where lo.course.Contains("IIO13200")
                     orderby lo.lastname
                     select new
                     {
                         Nimi = lo.lastname + "" + lo.firstname,
                         Asioid = lo.asioid,
                         Pvm = lo.date
                     };

        gvData.DataSource = kysely.ToList();
        gvData.DataBind();

    }
    protected void btnGetSelectedIlmos_Click(object sender, EventArgs e)
    {
        //Haetaan annetun opiskelijan ilmot
        ctx = new DemoxOyEntities();
        //tarkistetaan onko annetulla opiskelijalla ilmoja
        //VE asioid textboxistta
        //string jeppe = txtAsioid.Text;
        //VE asioid DDL:stä
        string jeppe = ddlStudents.SelectedValue;
        bool isIlmos = ctx.lasnaolots.Any(ilmo => ilmo.asioid.Contains(jeppe));
        if (isIlmos)
        {
            var oppilaanLasnaolot = from lo in ctx.lasnaolots
                                    where (lo.course.Contains("IIO13200") &
                                        lo.asioid.Contains(jeppe))
                                    orderby lo.date
                                    select new { Pvm = lo.date };
            gvData.DataSource = oppilaanLasnaolot.ToList();
            gvData.DataBind();
            lblMessages.Text = string.Format("Löytyi {0} läsnäoloa",
                oppilaanLasnaolot.Count());
        }
        else
        {
            lblMessages.Text = string.Format("Ei löytynyt ilmoittautumisia AsioID:llä {0}", jeppe);
        }
    }
    protected void btnGetIlmosGrouped_Click(object sender, EventArgs e)
    {
        //näytetään tulos html:n avulla joten gridview alta pois
        gvData.DataSource = null;
        gvData.DataBind();
        //Haetaan kaikki opintojakson ilmoittautumiset ja listataan kunkin opiskelijan läsnäolot
        ctx = new DemoxOyEntities();
        var lasnaolot = from lo in ctx.lasnaolots
                        where lo.course.StartsWith("IIO13200")
                        orderby lo.lastname
                        select new
                        {
                            Asioid = lo.asioid,
                            Nimi = lo.lastname + " " + lo.firstname,
                            Pvm = lo.date
                        };
        string opiskelija = "";
        DateTime? pvm; //muuttuja voi olla null, nullable
        //looppi
        foreach (var lasnaolo in lasnaolot)
        {
            pvm = lasnaolo.Pvm;
            if (opiskelija == lasnaolo.Nimi)
            {
                tulos.InnerHtml += pvm.Value.ToShortDateString() + "<br>";
            }
            else
            {
                opiskelija = lasnaolo.Nimi;
                tulos.InnerHtml += "<h3> + opiskelija + </h3>";
                tulos.InnerHtml += pvm.Value.ToShortDateString() + "<br>";
            }
        }
    }
}