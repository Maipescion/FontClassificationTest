import zmq
from keras.models import load_model

context = zmq.Context()
socket = context.socket(zmq.REP)
socket.bind("tcp://*:5555")

while True:
    bytes_received = socket.recv(3136)
    array_received = np.frombuffer(bytes_received, dtype=np.float32)

    model = load_model('model.h5')
    pred = model.predict(array_received)

    bytes_to_send = struct.pack('%sf' % len(nn_output), *pred)
    socket.sendall(bytes_to_send)
