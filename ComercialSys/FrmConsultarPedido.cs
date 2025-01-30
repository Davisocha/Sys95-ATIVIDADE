using ComClassSys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercialSys
{
    public partial class FrmConsultarPedido : Form
    {
        public FrmConsultarPedido()
        {
            InitializeComponent();
        }

        private void FrmConsultarPedido_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }
        private void CarregaGrid()
        {
            dgvConsultar.Rows.Clear();
            var pedidos = Pedido.ObterLista();
            int cont = 0;
            foreach (var pedido in pedidos)
            {
                var itens = ItemPedido.ObterListaPorPedido(pedido.Id);
                double ValorPedido = CalculaValorPedido(itens);
                dgvConsultar.Rows.Add();
                dgvConsultar.Rows[cont].Cells[0].Value = pedido.Id;
                dgvConsultar.Rows[cont].Cells[1].Value = pedido.Usuario.Id;
                dgvConsultar.Rows[cont].Cells[2].Value = pedido.Cliente.Id;
                dgvConsultar.Rows[cont].Cells[3].Value = pedido.Data;
                dgvConsultar.Rows[cont].Cells[4].Value = pedido.Status;
                dgvConsultar.Rows[cont].Cells[5].Value = pedido.Desconto;
                dgvConsultar.Rows[cont].Cells[6].Value = ValorPedido;
                cont++;
            }
        }
        private void CarregaGridID(int id)
        {
            dgvConsultar.Rows.Clear();
            var pedidos = Pedido.ObterListaID(id);
            int cont = 0;
            foreach (var pedido in pedidos)
            {
                var itens = ItemPedido.ObterListaPorPedido(pedido.Id);
                double ValorPedido = CalculaValorPedido(itens);
                dgvConsultar.Rows.Add();
                dgvConsultar.Rows[cont].Cells[0].Value = pedido.Id;
                dgvConsultar.Rows[cont].Cells[1].Value = pedido.Usuario.Id;
                dgvConsultar.Rows[cont].Cells[2].Value = pedido.Cliente.Id;
                dgvConsultar.Rows[cont].Cells[3].Value = pedido.Data;
                dgvConsultar.Rows[cont].Cells[4].Value = pedido.Status;
                dgvConsultar.Rows[cont].Cells[5].Value = pedido.Desconto;
                dgvConsultar.Rows[cont].Cells[6].Value = ValorPedido;
                cont++;
            }
        }
        private void CarregaGridCPF(string cpf)
        {
            dgvConsultar.Rows.Clear();
            var pedidos = Pedido.ObterListaCPF(cpf);
            int cont = 0;
            foreach (var pedido in pedidos)
            {
                var itens = ItemPedido.ObterListaPorPedido(pedido.Id);
                double ValorPedido = CalculaValorPedido(itens);
                dgvConsultar.Rows.Add();
                dgvConsultar.Rows[cont].Cells[0].Value = pedido.Id;
                dgvConsultar.Rows[cont].Cells[1].Value = pedido.Usuario.Id;
                dgvConsultar.Rows[cont].Cells[2].Value = pedido.Cliente.Id;
                dgvConsultar.Rows[cont].Cells[3].Value = pedido.Data;
                dgvConsultar.Rows[cont].Cells[4].Value = pedido.Status;
                dgvConsultar.Rows[cont].Cells[5].Value = pedido.Desconto;
                dgvConsultar.Rows[cont].Cells[6].Value = ValorPedido;
                cont++;
            }
        }
        private void CarregaGridSTATUS(string status)
        {
            dgvConsultar.Rows.Clear();
            var pedidos = Pedido.ObterListaSTATUS(status);
            int cont = 0;
            foreach (var pedido in pedidos)
            {
                var itens = ItemPedido.ObterListaPorPedido(pedido.Id);
                double ValorPedido = CalculaValorPedido(itens);
                dgvConsultar.Rows.Add();
                dgvConsultar.Rows[cont].Cells[0].Value = pedido.Id;
                dgvConsultar.Rows[cont].Cells[1].Value = pedido.Usuario.Id;
                dgvConsultar.Rows[cont].Cells[2].Value = pedido.Cliente.Id;
                dgvConsultar.Rows[cont].Cells[3].Value = pedido.Data;
                dgvConsultar.Rows[cont].Cells[4].Value = pedido.Status;
                dgvConsultar.Rows[cont].Cells[5].Value = pedido.Desconto;
                dgvConsultar.Rows[cont].Cells[6].Value = ValorPedido;
                cont++;
            }
        }
        private double CalculaValorPedido(List<ItemPedido> lista)
        {
            double valor = 0;
            foreach (var item in lista)
            {
                valor = item.ValorUnit * item.Quantidade - item.Desconto;
            }
            return valor;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

            if (btnID.Checked)
            {
                CarregaGridID(Convert.ToInt32(txtInfo.Text));
            }
            else CarregaGridCPF(txtInfo.Text);
            if (btnstatus.Checked)
            {
                CarregaGridSTATUS(txtInfo.Text);
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (btnID.Checked)
            {
                BtnBuscar.Visible = true;
                txtInfo.Visible = true;
            }
            else
            {
                BtnBuscar.Visible = false;
                txtInfo.Visible = false;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (btnCPF.Checked)
            {
                
                BtnBuscar.Visible = true;
                txtInfo.Visible = true;
               
            }
            else
            {
                BtnBuscar.Visible = false;
                txtInfo.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (btnstatus.Checked)
            {
                BtnBuscar.Visible = true;
                txtInfo.Visible = true;
            }
            else
            {
                BtnBuscar.Visible = false;
                txtInfo.Visible = false;
            }
        }
    }
}
