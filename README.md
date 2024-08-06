# Tariff Comparison

Running the project is very simple. If you have docker compose installed.

just run `docker compose up -d` to run back and front simultaneously. And `docker compose down` to shut down the loaded pods.

You can find swagger on port `http://localhost:5127/swagger/index.html`.
The front end can be found at `http://localhost:4000`.

There are two APIs to populate the system. 
`/register` and `/register/batch`. 

There is a route `/products` where you can query with annual consumption as its parameter to get a product list with their annual cost.
