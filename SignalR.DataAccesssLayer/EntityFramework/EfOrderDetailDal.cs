﻿using SignalR.DataAccesssLayer.Abstract;
using SignalR.DataAccesssLayer.Concrete;
using SignalR.DataAccesssLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccesssLayer.EntityFramework
{
    public class EfOrderDetailDal : GenericRepository<OrderDetail> , IOrderDetailDal
    {
        public EfOrderDetailDal(SignalRContext context) : base(context)
        {
        }
    }
}
