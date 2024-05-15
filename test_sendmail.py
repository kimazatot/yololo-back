import unittest
from sendemail import app

class TestFlaskApp(unittest.TestCase):
    def setUp(self):
        self.app = app.test_client()
        self.app.testing = True

    def test_sndmsg(self):
        response = self.app.post('/send_message')
        self.assertEqual(response.status_code, 200)









if __name__ == "__main__":
    unittest.main(verbosity=2)