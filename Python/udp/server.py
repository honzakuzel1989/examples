#!/usr/bin/env python
#for client can use nc -u <ip> <port>

import socket

class Server():
	def __init__(self, ip, port):
		self.__ip = ip
		self.__port = port
		self.__socket = socket.socket(
			socket.AF_INET,
			socket.SOCK_DGRAM)

	def listen(self):
		self.__socket.bind((self.__ip, self.__port))
		while True:
			data, addr = self.__socket.recvfrom(1024)
			print "%s - %s" % (str(addr), str(data))

if __name__ == "__main__":
	server = Server("127.0.0.1", 5005)
	server.listen()
	
