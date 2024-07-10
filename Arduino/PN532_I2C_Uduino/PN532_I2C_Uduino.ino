#include <Uduino.h>

#include <Wire.h>
#include <Adafruit_PN532.h>
 
#define SDA_PIN A4
#define SCL_PIN A5

Uduino uduino("MyReader"); 
 
Adafruit_PN532 nfc(SDA_PIN, SCL_PIN);
 
void setup(void) {
    Serial.begin(115200);
    nfc.begin();
    
    uint32_t versiondata = nfc.getFirmwareVersion();
    if (!versiondata) {
        uduino.print("Didn't find PN53x board");
        while (1);
    }
    nfc.SAMConfig();
    uduino.println("Waiting for NFC card...");
}
 
void loop(void) {
    uduino.update();
    if (uduino.isConnected()) {
    uint8_t success;
    uint8_t uid[] = { 0, 0, 0, 0, 0, 0, 0 };
    uint8_t uidLength;
 
    success = nfc.readPassiveTargetID(PN532_MIFARE_ISO14443A, uid, &uidLength);

    
    if (success) {
        // uduino.println("Found an NFC card!");
        // uduino.print("UID Length: ");uduino.print(uidLength, DEC);uduino.println(" bytes");
        // uduino.print("UID Value: ");
        for (uint8_t i=0; i < uidLength; i++) {
            // uduino.print("0x");
            uduino.print(uid[i], HEX);
        }
        uduino.println("");
        // uduino.delay(1000);
    }
    }
}
