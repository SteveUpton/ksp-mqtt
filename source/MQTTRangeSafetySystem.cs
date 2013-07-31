using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MqttLib;

namespace MQTTKSP {

    class MQTTRangeSafetySystem : Part
    {

        protected override void onFlightStart()  //Called when vessel is placed on the launchpad
        {

            System.Random rand = new System.Random();
            String clientID = "ksp" + rand.Next(100000);

            IMqtt _client;
            _client = MqttClientFactory.CreateClient("tcp://m2m.eclipse.org:1883", clientID);
            _client.PublishArrived += new PublishArrivedDelegate(client_PublishArrived);
            print("MQTT Client created");
            _client.Connect(true);
            print("MQTT Client connected");
            _client.Publish("ksp/test1/telemetry/blah", "Connected!", QoS.BestEfforts, false);
            print("MQTT Message published");
            _client.Subscribe("ksp/test1/cmd/rss", QoS.BestEfforts);   // Subscribe to rss command topic
            print("MQTT Client subscribed to command topic");

        }

        bool client_PublishArrived(object sender, PublishArrivedArgs e)
        {
            print("Received MQTT Message");
            print("Topic: " + e.Topic);
            print("Payload: " + e.Payload);

            parent.explode();
            this.explode();

            return true;
        }

    }

}
