using System;
using RoleTopMVC.Enums;

namespace RoleTopMVC.Models
{
    public class Pedido
    {
        public DateTime Data { get; set; }
        

        public Cliente Cliente { get; set; }
        public uint Status { get; set; }
        public ulong Id { get; set; }

        





        public Pedido( )
        {
            this.Cliente = new Cliente();
            this.Id = 0;
            this.Status = (uint) StatusPedido.PENDENTE; 
        



        }

    }

}