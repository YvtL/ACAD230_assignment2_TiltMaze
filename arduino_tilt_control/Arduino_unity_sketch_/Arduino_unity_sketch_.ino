int tiltX = 9;    // Pin connected to X-axis tilt sensor
int tiltNegX = 10; // Pin connected to -X-axis tilt sensor
int tiltY = 11;    // Pin connected to Y-axis tilt sensor
int tiltNegY = 12; // Pin connected to -Y-axis tilt sensor

void setup() {
  // Set up each tilt sensor pin as an input
  pinMode(tiltX, INPUT);
  pinMode(tiltNegX, INPUT);
  pinMode(tiltY, INPUT);
  pinMode(tiltNegY, INPUT);

  // Start serial communication to send data to Unity
  Serial.begin(2000000);
}

void loop() {
  // Read the state of each tilt sensor
  int X = digitalRead(tiltX);       // Read the X tilt sensor
  int NegX = digitalRead(tiltNegX); // Read the -X tilt sensor
  int Y = digitalRead(tiltY);       // Read the Y tilt sensor
  int NegY = digitalRead(tiltNegY); // Read the -Y tilt sensor

  // Send data to Unity in a formatted string (X, NegX, Y, NegY)
  //change to if statemnet to be either -1 0 1
  if (X == 1)
  {
    Serial.print(2);
  }
  else if(NegX == 1)
  {
     Serial.print(0);
  }
  else
  {
      Serial.print(1);
  }

  if (Y == 1)
  {
    Serial.println(2);
  }
  else if(NegY == 1)
  {
     Serial.println(0);
  }
  else
  {
      Serial.println(1);
  }


  // Add a small delay to control data transmission speed
  delay (0);
}
