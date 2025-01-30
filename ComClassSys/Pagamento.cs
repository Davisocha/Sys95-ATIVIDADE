using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComClassSys
{
    public class Pagamento
    {
        public int Id { get; set; }
        public Caixa Id_Caixa { get; set; }
        public Pedido Id_Pedido { get; set; }
        public string Tipo_Pagamento { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }


        public Pagamento()
        {
            Pagamento pagamento = new();
        }

        public Pagamento(int id, Caixa id_caixa, Pedido id_Pedido, string tipo_Pagamento, double valor, DateTime data)
        {
            Id = id;
            Id_Caixa = id_caixa;
            Id_Pedido = id_Pedido;
            Tipo_Pagamento = tipo_Pagamento;
            Valor = valor;
            Data = data;
        }
        public Pagamento(Caixa id_caixa, Pedido id_Pedido, string tipo_Pagamento, double valor, DateTime data)
        {
            Id_Caixa = id_caixa;
            Id_Pedido = id_Pedido;
            Tipo_Pagamento = tipo_Pagamento;
            Valor = valor;
            Data = data;
        }

        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandText = $"insert into pagamentos values (0, '{Id_Caixa}','{Id_Pedido}',{Tipo_Pagamento}, {Valor}, {Data})";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            Id = Convert.ToInt32(cmd.ExecuteScalar());

        }

        public static Pagamento ObterPorId(int id)
        {
            Pagamento pagamento = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select id, id_caixa, id_pedido, tipo_pagamento, valor, data from pagamentos where id = {id}";

            var dr = cmd.ExecuteReader();
            if (dr.Read())

            {
                pagamento = new(dr.GetInt32(0),
                    Caixa.ObterPorId(dr.GetInt32(1)),
                    Pedido.ObterPorId(dr.GetInt32(2)),
                    dr.GetString(3),
                     dr.GetDouble(4),
                    dr.GetDateTime(5))
                    ;
            }
            cmd.Connection.Close();
            return pagamento;
        }
        public static List<Pagamento> ObterLista()
        {
            List<Pagamento> pagamento = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = "select * from pagamentos order by nome asc";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pagamento.Add(new(dr.GetInt32(0),
                    Caixa.ObterPorId(dr.GetInt32(1)),
                    Pedido.ObterPorId(dr.GetInt32(2)),
                    dr.GetString(3),
                     dr.GetDouble(4),
                    dr.GetDateTime(5)));
            }
            cmd.Connection.Close();
            return pagamento;
        }
    }
}
