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
            client.Subscribe("ksp/test1/cmd/#", QoS.BestEfforts);   // Subscribe to rss command topic
            print("Remote Control System subscribed to command topic");
        }

        bool client_PublishArrived(object sender, PublishArrivedArgs e)
        {
            string commandTopic = e.Topic;
            FlightCtrlState flightControlState = FlightInputHandler.state;

            if (commandTopic.EndsWith("stage"))
            {
                Staging.ActivateNextStage();
            }
            else if (commandTopic.EndsWith("throttle"))
            {
                flightControlState.mainThrottle = float.Parse(e.Payload.ToString());
            }
            
            return true;
        }

    }

}