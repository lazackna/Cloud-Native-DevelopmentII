using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Commands
{
    public class DeleteWeatherCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
