﻿using AnnouncementApp.Base.Response;
using AnnouncementApp.Data.Models;
using AnnouncementApp.DTO;
using AnnouncementApp.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.Service.Abstract
{
    public interface IAnnouncementService : IBaseService<AnnouncementDto,Announcement>
    {

        public string GetDetail(int id);
    }
}
