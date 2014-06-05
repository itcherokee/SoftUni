public class Product {
	public String getName() {
		return name;
	}

	public void setName(String name) {
		if (name == null) {
			throw new IllegalArgumentException("Product name cannot be empty!");
		}
		
		this.name = name;
	}

	public double getPrice() {
		return price;
	}

	public void setPrice(double price) {
		this.price = price;
	}

	private String name;
	private double price;

	public Product(String name, double price) {
		this.name = name;
		this.price = price;
	}
}