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
  Serial.begin(115200);
}

void loop() {
  // Read the state of each tilt sensor
  int X = digitalRead(tiltX);       // Read the X tilt sensor
  int NegX = digitalRead(tiltNegX); // Read the -X tilt sensor
  int Y = digitalRead(tiltY);       // Read the Y tilt sensor
  int NegY = digitalRead(tiltNegY); // Read the -Y tilt sensor

  // Send data to Unity in a formatted string (X, NegX, Y, NegY)
  Serial.print(X); 
  Serial.print(NegX); 
  Serial.print(Y);
  Serial.println(NegY);

  // Add a small delay to control data transmission speed
  delay(1);
}
