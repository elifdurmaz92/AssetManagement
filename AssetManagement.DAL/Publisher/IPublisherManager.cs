using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DAL.Publisher
{
   public interface IPublisherManager
    {
        Task Publish(string value);
    }
}
