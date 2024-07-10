#include <Uduino.h>
Uduino uduino("MyReader"); 
#include <Wire.h>
#include "MFRC522_I2C.h"

#define RST_PIN 6 // Arduino UNO
// #define RST_PIN 14 // D5 on NodeMCU

// 0x28 is i2c address of the NFC Reader. Check your address with i2cscanner if not match.



MFRC522 mfrc522(0x28, RST_PIN);   // Create MFRC522 instance.
String rfid_str = "";
void setup() {
  Serial.begin(115200);           // 设置波特率为115200
  Wire.begin();                   // 初始化 I2C
  mfrc522.PCD_Init();             // 初始化 MFRC522
  uduino.println("Waiting for NFC card...");
}

void loop() {
  uduino.update();
  if (uduino.isConnected()) {
    if ( ! mfrc522.PICC_IsNewCardPresent() || ! mfrc522.PICC_ReadCardSerial() ) {
      uduino.delay(50);
      return;
    }
    rfid_str = "";//字符串清空
    // Serial.print(F("Card UID:"));
    for (byte i = 0; i < mfrc522.uid.size; i++) {// 转储 UID
      rfid_str = rfid_str + String(mfrc522.uid.uidByte[i], HEX);  //转为字符串
      //    Serial.print(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " ");
      //    Serial.print(mfrc522.uid.uidByte[i], HEX);
    }
    uduino.println(rfid_str);
  }
}
