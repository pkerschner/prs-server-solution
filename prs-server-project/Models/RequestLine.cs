using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace prs_server_project.Models {

    public class RequestLine {

        public int Id { get; set; }
        public int Quantity { get; set; } = 1;

        public int RequestId { get; set; }
        [JsonIgnore] // Attribute to resolve cyclical error
        public virtual Request Request { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public RequestLine() { }
    }
}
