﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clifton.ServiceInterfaces
{
	public interface IService
	{
		void Initialize(IServiceManager srvMgr);
		void FinishedInitialization();
	}
}
