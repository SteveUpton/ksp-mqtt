using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MqttLib;

namespace MQTTKSP
{

    class MQTTRemoteControl : MQTTPartModule
    {

        public override void OnStart(PartModule.StartState state)
        {
            base.OnStart(state);
            client.PublishArrived += new PublishArrivedDelegate(client_PublishArrived);
            client.Subscribe("ksp/test1/cmd/rc", QoS.BestEfforts);   // Subscribe to rss command topic
            print("Remote Control System subscribed to command topic");
        }

        bool client_PublishArrived(object sender, PublishArrivedArgs e)
        {
            Staging.ActivateNextStage();
            return true;
        }

    }

}