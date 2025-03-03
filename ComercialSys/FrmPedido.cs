﻿using ComClassSys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercialSys
{
    public partial class FrmPedido : Form
    {
        public FrmPedido()
        {
            InitializeComponent();
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            txtVendedor.Text = Program.Usuario.Id + " - " + Program.Usuario.Nome;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
            if (textBox2.Text.Length > 0)
            {
                var cliente = Cliente.ObterPorId(int.Parse(textBox2.Text));
                if (cliente.Id > 0)
                {
                    textBox3.Text = cliente.Nome;
                }
            }
        }
        private void btnAbrirNovo_Click(object sender, EventArgs e)
        {
            Pedido pedido = new();
            pedido.Cliente = Cliente.ObterPorId(int.Parse(textBox2.Text));
            pedido.Usuario = Program.Usuario;
            pedido.Status = "A";
            pedido.Desconto = 0;
            pedido.Inserir();
            txtNumeroPedido.Text = pedido.Id.ToString();
            gbxProduto.Enabled = true;
            btnAbrirNovo.Enabled = false;

        }
        Produto produto = new();
        private void txtCodBar_TextChanged(object sender, EventArgs e)
        {
            if (txtCodBar.Text.Length > 4)
            {
                produto = Produto.BuscarPorId(int.Parse(txtCodBar.Text));
                if (produto.Id > 0)
                {
                    txtDescricao.Text = produto.Descricao;
                    txtValorUnit.Text = produto.ValorUnit.ToString();
                    lblDescMax.Text = $"R$ {produto.ClasseDesconto * produto.ValorUnit}";

                }


            }
        }

        private void btnInserirItem_Click(object sender, EventArgs e)
        {
            //Busca o produto
            ItemPedido itemPedido = new(
                int.Parse(txtNumeroPedido.Text)
                , Produto.BuscarPorId(int.Parse(txtCodBar.Text))
                , double.Parse(txtValorUnit.Text)
                , double.Parse(txtQuantidade.Text)
                , double.Parse(txtDescontoItem.Text)
            );
            itemPedido.Inserir();
            // limpa controles
            txtCodBar.Clear();
            //txtDesconto.Text = "0";
            txtDescricao.Clear();
            txtQuantidade.Text = "1";
            txtValorUnit.Clear();
            txtCodBar.Focus();

            // limpar e carrega o datagrid
            CarregaGrid();



        }
        private void CarregaGrid()
        {
            dgvItens.Rows.Clear();
            var items = ItemPedido.ObterListaPorPedido(int.Parse(txtNumeroPedido.Text));
            int cont = 0;
            double subTotal = 0;
            foreach (var item in items)
            {
                dgvItens.Rows.Add();
                dgvItens.Rows[cont].Cells[0].Value = $"#{cont + 1}";  // seq
                dgvItens.Rows[cont].Cells[1].Value = item.Produto.CodBarras; // codbar
                dgvItens.Rows[cont].Cells[2].Value = item.Produto.Descricao; // descrição
                dgvItens.Rows[cont].Cells[3].Value = item.Produto.UnidadeVenda; // unidade de venda
                dgvItens.Rows[cont].Cells[4].Value = item.ValorUnit; // valor unit
                dgvItens.Rows[cont].Cells[5].Value = item.Quantidade; // quantidade
                dgvItens.Rows[cont].Cells[6].Value = item.Desconto; // desconto
                dgvItens.Rows[cont].Cells[7].Value = item.ValorUnit * item.Quantidade - item.Desconto; // valor item
                dgvItens.Rows[cont].Cells[8].Value = item.Id;
                subTotal += item.ValorUnit * item.Quantidade - item.Desconto;
                cont++;
            }
            txtTotal.Text = "R$ " + subTotal.ToString();

        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantidade.Text.Length > 0)
            {
                lblDescMax.Text = $"R$ {produto.ClasseDesconto * produto.ValorUnit * decimal.Parse(txtQuantidade.Text)}";
            }
        }

        private void dgvItens_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvItens.Rows.Count > 0)
            {
                MessageBox.Show("Vamos remover a linha: " + e.RowIndex);
            }

        }

        private void btnExcluirItem_Click(object sender, EventArgs e)
        {
            if (dgvItens.Rows.Count > 0)
            {
                int linha = dgvItens.CurrentRow.Index;
                string seq = dgvItens.Rows[linha].Cells[0].Value.ToString();
                var confirma = MessageBox.Show($"Deseja confirmar a exclusão do Item {seq}?"
                    , "Excluir Item",
                    MessageBoxButtons.YesNo
                    , MessageBoxIcon.Warning
                    , MessageBoxDefaultButton.Button2
                    );
                if (confirma == DialogResult.Yes)
                {
                    ItemPedido.Remover(Convert.ToInt32(dgvItens.Rows[linha].Cells[8].Value));
                    CarregaGrid();
                }
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            var pedido = Pedido.ObterPorId(Convert.ToInt32(txtNumeroPedido.Text));
            pedido.Alterar("F");
            MessageBox.Show("Pedido fechado com sucesso");
            this.Close();
        }



            
            
    }
}
