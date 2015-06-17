#!/usr/bin/env python
#for server (listener) can use nc -lu <port>

import socket

class Client():
	def __init__(self, ip, port):
		self.__ip = ip
		self.__port = port
		self.__socket = socket.socket(
			socket.AF_INET,		#internet
			socket.SOCK_DGRAM)	#udp
	
	def send_message(self, msg):
		print "msg=", msg, ",", "ip=", self.__ip, ",", "port=", self.__port
		self.__socket.sendto(msg, (self.__ip, self.__port))

if __name__ == "__main__":
	from time import sleep

	client = Client("127.0.0.1", 5005)
	counter = 0
	while True:
		client.send_message(str(counter))
		counter += 1
		sleep(1)
	
