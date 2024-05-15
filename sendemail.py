from flask import Flask, request, redirect, render_template, url_for
from flask_mail import Mail, Message
import datetime
import time
import schedule
import psycopg2

app = Flask(__name__)

mail = Mail(app)


app.config['MAIL_SERVER'] = 'smtp.gmail.com'
app.config['MAIL_PORT'] = 587
app.config['MAIL_USE_TLS'] = True
app.config['MAIL_USERNAME'] = 'miralibaltabaev59@gmail.com'
app.config['MAIL_PASSWORD'] = 'moyasemya56'
app.config['MAIL_DEFAULT_SENDER'] = 'miralibaltabaev59@gmail.com'








MESSAGE = "сообщение"
users = None

def rec_email():
    global users
    try:
        with psycopg2.connect(dbname="api_users", user="postgres", password="moyasemya56", host="localhost",
                              port="5432") as conn:
            with conn.cursor() as cur:
                firstdata = '''
                    SELECT email FROM USERS;
                '''
                cur.execute(firstdata)
                users = cur.fetchall()
                conn.commit()
    except Exception as e:
        print(f"Error creating database: {e}")

def sendmail():
    global users
    with mail.connect() as conn:
        for user in users:
            email = user[0]
            msg = Message("",recipients=[email])
            msg.body = MESSAGE
            try:
                mail.send(msg)
                conn.send(msg)
            except Exception as e:
                print(f"Проблема: \t {e}")
schedule.every().week.do(rec_email)
schedule.every().week.do(sendmail)

@app.route('/send_message', methods=['POST'])
def send_message():
    rec_email()
    sendmail()
    return "Сообщения отправлены успешно!"


if __name__ == '__main__':
    app.run(port=9584, debug=True)
while True:
    schedule.run_pending()
    time.sleep(1000)