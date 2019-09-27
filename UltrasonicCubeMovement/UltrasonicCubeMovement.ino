
#define TRIGGER 2
#define ECHO 3

int data;

void setup() {
  Serial.begin(9600);
  pinMode(TRIGGER, OUTPUT);
  pinMode(ECHO, INPUT);
}

void loop() {

  data = calculateDistance(TRIGGER, ECHO);

  if (data < 50) {
    Serial.write(data);
    delay(20);
  }
}

int calculateDistance(int trigger, int echo) {

  digitalWrite(trigger, LOW);
  delayMicroseconds(2);
  digitalWrite(trigger, HIGH);
  delayMicroseconds(8);
  digitalWrite(trigger, LOW);

  double distance = ( pulseIn(echo, HIGH) ) * 343.2 / 20000;
  return distance;
}
