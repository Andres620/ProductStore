CREATE TABLE usuarios(
	id INT PRIMARY KEY IDENTITY (1,1),
	nombre VARCHAR(255) NOT NULL,
	correo_electronico VARCHAR(100) NOT NULL,
	contrasena VARCHAR(100) NOT NULL
);

CREATE TABLE productos(
	id INT PRIMARY KEY IDENTITY (1,1),
	nombre VARCHAR(255) NOT NULL,
	descripcion VARCHAR(100) NOT NULL,
	precio VARCHAR(100) NOT NULL
);

CREATE TABLE pedidos(
	id INT PRIMARY KEY IDENTITY (1,1),
	usuario_id INT NOT NULL,
	producto_id INT NOT NULL,
	fecha DATETIME NOT NULL,
	cantidad INT NOT NULL
	FOREIGN KEY (usuario_id) REFERENCES  usuarios(id),
	FOREIGN KEY (producto_id) REFERENCES  productos(id)
);
