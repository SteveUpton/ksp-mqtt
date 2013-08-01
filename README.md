ksp-mqtt
========

MQTT extensions for Kerbal Space Program.

Very much a work-in-progress at this point and not ready for actual use. Topics and broker are hard coded and unsecured.

Currently able to remotely stage using the` MQTT Remote` part and detonate using the `Range Safety System` part. Broker used is `http://m2m.eclipse.org:1883` and commands are listened for on `ksp/test1/commands/#` for staging and `ksp/test1/cmd/rss` for range safety.

Plans are to have the parts that publish telemety as well as a more comprehensive remote control system.
