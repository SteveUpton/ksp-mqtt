using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MqttLib;

namespace MQTTKSP
{
    class MQTTPartModule : PartModule {

        public IMqtt client;

        public override void OnStart(PartModule.StartState state)
        {
            // No need to create a client if we're in the VAB/SPH
            if (vessel == null)
            {
                return;
            }

            System.Random rand = new System.Random();
            String clientID = "ksp" + rand.Next(100000);

            client = MqttClientFactory.CreateClient("tcp://m2m.eclipse.org:1883", clientID);
            client.Connect(true);
            print("MQTT Client connected");
            client.Publish("ksp/test1/tlm/alerts", "Connected!", QoS.BestEfforts, false);
        }

    }
}
