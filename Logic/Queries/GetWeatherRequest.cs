﻿using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Queries
{
    public class GetWeatherRequest : IRequest<List<ApiWeather>>
    {
    }
}
