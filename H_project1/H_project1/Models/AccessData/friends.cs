namespace H_project1.Models.AccessData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class friends
    {
        public int id { get; set; }

        public int idUserSendRequest { get; set; }

        public int idUserRequested { get; set; }

        public bool accepted { get; set; }

        public bool Ignored { get; set; }
    }
}
