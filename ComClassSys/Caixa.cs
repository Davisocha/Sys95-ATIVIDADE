using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComClassSys
{
    public class Caixa
    {
        public int Id { get; set; }
        public Usuario? Usuario_id { get; set; }
        public DateTime Data_Abertura { get; set; }
        public double Saldo_Inicial { get; set; }
        public string Status { get; set; }


        public Caixa()
        {
            Caixa caixa = new();
        }
        public Caixa(int id, Usuario usuario_id, DateTime data_abertura, double saldo_inicial, string status)
        {
            Id = id;
            Usuario_id = usuario_id;
            Data_Abertura = data_abertura;
            Saldo_Inicial = saldo_inicial;
            Status = status;
        }

        public Caixa(Usuario usuario_id, DateTime data_abertura, double saldo_inicial, string status)
        {
            Usuario_id = usuario_id;
            Data_Abertura = data_abertura;
            Saldo_Inicial = saldo_inicial;
            Status = status;
        }

        public void Inserir()
        {
            var cmd = Banco.Abrir();
            cmd.CommandText = $"insert into caixas values (0, '{Usuario_id}','{Data_Abertura}',{Saldo_Inicial}, {Status})";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            Id = Convert.ToInt32(cmd.ExecuteScalar());

        }

        public static Caixa ObterPorId(int id)
        {
            Caixa caixa = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = $"select id, usuario_id ,data_abertura ,saldo_inicial,status from caixas where id = {id}";
            var dr = cmd.ExecuteReader();
            if (dr.Read())

            {
                caixa = new(dr.GetInt32(0),
                    Usuario.ObterPorId(dr.GetInt32(1)),
                    dr.GetDateTime(2),
                    dr.GetDouble(3),
                    dr.GetString(4))
                    ;
            }
            cmd.Connection.Close();
            return caixa;
        }
        public static List<Caixa> ObterLista()
        {
            List<Caixa> caixa = new();
            var cmd = Banco.Abrir();
            cmd.CommandText = "select * from caixas order by nome asc";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                caixa.Add(new(dr.GetInt32(0),
                    Usuario.ObterPorId(dr.GetInt32(1)),
                     dr.GetDateTime(2),
                     dr.GetDouble(3),
                     dr.GetString(4)));
            }
            cmd.Connection.Close();
            return caixa;
        }

        public bool Atualizar()
        {
            bool resposta = false;
            var cmd = Banco.Abrir();// nome'{Nome}', sigla
            cmd.CommandText = $"update caixas set '(usuario_id = '{Usuario_id}',data_abertura = '{Data_Abertura}',saldo_inicial = '{Saldo_Inicial}',status = '{Status}'where id = {Id}";
            return cmd.ExecuteNonQuery() > 0 ? true : false;

        }
    }
}
