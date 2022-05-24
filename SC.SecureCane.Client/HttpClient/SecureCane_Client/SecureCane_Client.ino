#include <ArduinoJson.h>

struct ConnectionStrings {
  char backendUrl[64];
  char rabbitUrl[64];
};

struct MQTT {
  char *vhost;
  char **pubs;
  char **subs;
};

// Our configuration structure.
//
// Never use a JsonDocument to store the configuration!
// A JsonDocument is *not* a permanent storage; it's only a temporary storage
// used during the serialization phase. See:
// https://arduinojson.org/v6/faq/why-must-i-create-a-separate-config-object/
struct Config {
  // char hostname[64];
  // int port;
  ConnectionStrings connectionStrings;
  MQTT mqtt;
};



const char *filename = "{\"urls\": {\"b\":\"https://test-preprod.placesm-portfolio.fr\",\"r\":\"https://rabbit-preprod.placesm-portfolio.fr\"},\"MQTT\": {\"Vhost\": \"\\vhost\",\"Pub\": [\"GeoLoc\",\"WellArrived\",\"Accident\",\"InternalSoftwareCrash\"],\"Sub\": [\"CallToAction\",\"UpdateInternalSoftware\"]}}";  // <- SD library
const int capacity = JSON_OBJECT_SIZE(3) + JSON_OBJECT_SIZE(2) + JSON_OBJECT_SIZE(3) + 2*JSON_ARRAY_SIZE(2);
Config config;                       // <- global configuration object

// Loads the configuration from a file
void loadConfiguration(const char *filename, Config &config) {
  // Open file for reading
  // File file = SD.open(filename);
// Compute the required size
  // Allocate a temporary JsonDocument
  // Don't forget to change the capacity to match your requirements.
  // Use https://arduinojson.org/v6/assistant to compute the capacity.
  StaticJsonDocument<1512> doc;

  // Deserialize the JSON document
  DeserializationError error = deserializeJson(doc, filename);
  if (error)
    Serial.println(F("Failed to read string, using default configuration"));

  
  // Copy values from the JsonDocument to the Config
  //config.hello = doc["hello"] | "2731";

  strlcpy(config.connectionStrings.backendUrl,                     // <- destination
          doc["urls"]["b"] | "example.com",  // <- source
          sizeof(config.connectionStrings.backendUrl));            // <- destination's capacity
  
  strlcpy(config.connectionStrings.rabbitUrl,                     // <- destination
          doc["urls"]["r"] | "example.com",  // <- source
          sizeof(config.connectionStrings.rabbitUrl));            // <- destination's capacity

  strlcpy(config.mqtt.vhost,                     // <- destination
          doc["MQTT"]["Vhost"] | "/vhost",  // <- source
          sizeof(config.mqtt.vhost));            // <- destination's capacity
  strlcpy(config.mqtt.pubs[0],                     // <- destination
          doc["MQTT"]["Pub"][0] | NULL,  // <- source
          sizeof(char *));            // <- destination's capacity
  strlcpy(config.mqtt.subs[0],                     // <- destination
          doc["MQTT"]["Sub"][0] | NULL,  // <- source
          sizeof(char *));            // <- destination's capacity
  // Close the file (Curiously, File's destructor doesn't close the file)
  //file.close();
}

void testLoading(Config &config) {
  Serial.print("ConnectionStrings.BackendUrl : ");
  Serial.println(config.connectionStrings.backendUrl);
  Serial.println();
  Serial.print("ConnectionStrings.RabbitMQ : ");
  Serial.print(config.connectionStrings.rabbitUrl);
  Serial.println();
  Serial.print("MQTT.vhost : ");
  Serial.print(config.mqtt.vhost);
  Serial.println();
  Serial.print("MQTT.Pub[0] : ");
  Serial.print(config.mqtt.pubs[0]);
  Serial.println();
  Serial.print("MQTT.Sub[0] : ");
  Serial.print(config.mqtt.subs[0]);
  Serial.println();

}


void setup() {
  // Initialize Serial port (DEBUG)
  Serial.begin(9600);
  while (!Serial) continue;
  Serial.println();

  // Initialize SIM port
  // truc.Begin ??

  // Init config (with http call ??)
  loadConfiguration(filename, config);
  
  Serial.println();
  Serial.println();
  Serial.println("--------- TESTS CONFIGURATION ---------");
  testLoading(config);
  Serial.println();
  Serial.println();
  Serial.println();

  return;

  //
  // Allocate the JSON document
  // Inside the brackets, 200 is the RAM allocated to this document.
  // Don't forget to change this value to match your requirement.
  // Use arduinojson.org/v6/assistant to compute the capacity.
  StaticJsonDocument<200> doc;

  // StaticJsonObject allocates memory on the stack, it can be
  // replaced by DynamicJsonDocument which allocates in the heap.
  //
  // DynamicJsonDocument  doc(200);

  // Add values in the document
  //
  doc["sensor"] = "gps";
  doc["time"] = 1351824120;

  // Add an array.
  //
  JsonArray data = doc.createNestedArray("data");
  data.add(48.756080);
  data.add(2.302038);

  // Generate the minified JSON and send it to the Serial port.
  //
  serializeJson(doc, Serial);
  // The above line prints:
  // {"sensor":"gps","time":1351824120,"data":[48.756080,2.302038]}

  // Start a new line
  Serial.println();

  // Generate the prettified JSON and send it to the Serial port.
  //
  serializeJsonPretty(doc, Serial);
  // The above line prints:
  // {
  //   "sensor": "gps",
  //   "time": 1351824120,
  //   "data": [
  //     48.756080,
  //     2.302038
  //   ]
  // }
}

char incomingByte = 0;
int byteCounter = 0;
int loopCounter = 0;
char *namePtr;
void loop() {
   // send data only when you receive data:
  if (Serial.available() > 0){
    // read the incoming byte:
    incomingByte = (char)Serial.read();
    byteCounter++;
    if (incomingByte == '+'){
      Serial.print("Bytes counter : ");
      Serial.println(byteCounter);
    }
    // say what you got:
    Serial.print("Read : ");
    Serial.println(incomingByte);
    Serial.print("Loop counter : ");
    Serial.println(loopCounter);
  }
  loopCounter++;
}