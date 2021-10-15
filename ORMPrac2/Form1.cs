﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORMPrac2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Model.DB2EntityContainer db = new Model.DB2EntityContainer())
            {
                var oAgents = db.AGENTS.ToList();
                if (oAgents.Count > 0)
                {
                    MessageBox.Show("La base de datos ya contiene informacion", "Operacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Todo
                    //Se debe llenar la base de datos
                    using (var dbTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            List<Model.AGENTS> agentes = new List<Model.AGENTS>();

                            agentes.Add(new Model.AGENTS { AGENT_CODE = 7, AGENT_NAME = "Ramasundar", WORKING_AREA = "Bangalore", COMISSION = 0.15m, COUNTRY = "", PHONE_NO = "077-25814763" });
                            agentes.Add(new Model.AGENTS { AGENT_CODE = 3, AGENT_NAME = "Alex", WORKING_AREA = "London", COMISSION = 0.13m, COUNTRY = "", PHONE_NO = "075-12458969" });
                            agentes.Add(new Model.AGENTS { AGENT_CODE = 8, AGENT_NAME = "Alford", WORKING_AREA = "New York", COMISSION = 0.12m, COUNTRY = "", PHONE_NO = "044-25874365" });
                            agentes.Add(new Model.AGENTS { AGENT_CODE = 10, AGENT_NAME = "SantaKumar", WORKING_AREA = "Chennai", COMISSION = 0.14m, COUNTRY = "", PHONE_NO = "007-22388644" });
                            agentes.Add(new Model.AGENTS { AGENT_CODE = 12, AGENT_NAME = "Lucida", WORKING_AREA = "SanJose", COMISSION = 0.12m, COUNTRY = "", PHONE_NO = "044-52981425" });
                            agentes.Add(new Model.AGENTS { AGENT_CODE = 5, AGENT_NAME = "Anderson", WORKING_AREA = "Brisban", COMISSION = 0.13m, COUNTRY = "", PHONE_NO = "045-21447739" });
                            agentes.Add(new Model.AGENTS { AGENT_CODE = 4, AGENT_NAME = "Ivan", WORKING_AREA = "Torento", COMISSION = 0.15m, COUNTRY = "", PHONE_NO = "008-22544166" });

                            List<Model.CUSTOMER> cliente = new List<Model.CUSTOMER>();
                            cliente.Add(new Model.CUSTOMER { CUST_CODE = 13, CUST_NAME = "Holmes", CUST_CITY = "London", WORKING_AREA = "London",  CUST_COUNTRY = "Uk",  });


                            db.AGENTS.AddRange(agentes);
                            db.SaveChanges();
                            dbTransaction.Commit();

                            MessageBox.Show("La base de datos ha sido poblada con exito", "Operacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            dbTransaction.Rollback();
                            MessageBox.Show("Ocurrio un error y la base de datos no pudo ser poblada \n \n la aplicacion se cerrara.", "Error encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();


                        }




                    }

                        
                }

                button1.Enabled = false;
            }
        }
    }
}
