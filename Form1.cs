using Grupo_Nellise.Properties;

namespace Grupo_Nellise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool topMost = false;


        private void Form1_Load(object sender, EventArgs e)
        {
            txtAnotacoes.Text = Properties.Settings.Default.anotacoes.ToString();
        }

        private void btnPin_Click(object sender, EventArgs e)
        {
            if (topMost == false) { TopMost = true; topMost = true; btnPin.Text = "Fixado"; }
            else { TopMost = false; topMost = false; btnPin.Text = "Fixar"; }
        }

        private void txtLeaveFocus(object sender, EventArgs e)
        {
            AtualizarDatas();
        }

        private void AtualizarDatas()
        {
            MaskedTextBox[] vencimentos =
            {
                txtVcto1,
                txtVcto2,
                txtVcto3,
                txtVcto4,
                txtVcto5,
                txtVcto6,
                txtVcto7,
                txtVcto8,
                txtVcto9,
                txtVcto10
            };
            TextBox[] resultados =
            {
                txtRes1,
                txtRes2,
                txtRes3,
                txtRes4,
                txtRes5,
                txtRes6,
                txtRes7,
                txtRes8,
                txtRes9,
                txtRes10
            };

            if (!DateTime.TryParse(txtEmissao.Text, out DateTime emissao))
                return;

            for (int i = 0; i < vencimentos.Length; i++)
            {
                if (DateTime.TryParse(vencimentos[i].Text, out DateTime vencimento))
                {
                    int dias = (vencimento - emissao).Days;

                    resultados[i].Text = dias.ToString();
                }
                else
                {
                    resultados[i].Text = "";
                }
            }
        }

        private void txtFocusSelect(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                if (sender is MaskedTextBox mtb)
                {
                    mtb.SelectAll();
                }
            });
        }

        private void txtClickCopy(object sender, EventArgs e)
        {
            if (sender is TextBoxBase txt)
            {
                if (txt.TextLength > 0) { Clipboard.SetText(txt.Text); }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MaskedTextBox[] vencimentos =
            {
                txtEmissao,
                txtVcto1,
                txtVcto2,
                txtVcto3,
                txtVcto4,
                txtVcto5,
                txtVcto6,
                txtVcto7,
                txtVcto8,
                txtVcto9,
                txtVcto10
            };
            TextBox[] resultados =
            {
                txtRes1,
                txtRes2,
                txtRes3,
                txtRes4,
                txtRes5,
                txtRes6,
                txtRes7,
                txtRes8,
                txtRes9,
                txtRes10
            };
            for (int i = 0; i < vencimentos.Length; i++)
            {
                try
                {
                    vencimentos[i].Clear();
                    resultados[i].Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*int lastPosX = this.Location.X;
            int lastPosY = this.Location.Y;

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        this.Width = 273;
                        this.Height = 429;
                        //this.CenterToScreen();
                        this.Text = "Grupo Nellise | Calculadora de Vencimentos";
                        break;
                    }
                case 1:
                    {
                        this.Width = 273;
                        this.Height = 429;
                        //this.CenterToScreen();
                        this.Text = "Grupo Nellise | Anotações";
                        break;
                    }
                default:
                    break;
            }*/
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.anotacoes = txtAnotacoes.Text;
            Settings.Default.Save();
        }

        private void btnClear_Anno_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Limpar anotações?", "Grupo Nellise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                txtAnotacoes.Clear();
            }
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            float nfPercent = 0;
            if (txtRoyal.TextLength > 0 && txtCost.TextLength > 0)
            {
                try
                {
                    nfPercent = ((float.Parse(txtRoyal.Text) / float.Parse(txtCost.Text)) * 100 - 100) * -1;
                    string substr = nfPercent.ToString().Substring(0, 6);
                    txtPercentRoyal.Text = substr;
                }
                catch { }
            }
        }

        private void txtRoyal_Enter(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                if (sender is MaskedTextBox mtb)
                {
                    mtb.SelectAll();
                }
            });
        }

        private void txtVcto1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void txtRoyal_Enter_1(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                if (sender is MaskedTextBox mtb)
                {
                    mtb.SelectAll();
                }
            });
        }

        private void txtValorPedido_Leave(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                if (sender is MaskedTextBox mtb)
                {
                    
                }
            });
        }
    }
}
