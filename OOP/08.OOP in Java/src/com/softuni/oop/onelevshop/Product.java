package com.softuni.oop.onelevshop;

public abstract class Product implements Buyable {
    private String name;
    private double priceOfProduct;
    private int quantity;
    private AgeRestriction ageRestriction;

    protected Product(String name, double price, int quantity, AgeRestriction ageRestriction) {
        this.setName(name);
        this.setPrice(price);
        this.setQuantity(quantity);
        this.setAgeRestriction(ageRestriction);
    }

    public String getName() {
        return this.name;
    }

    private void setName(String name) {
        if (name == null || name.equals("")) {
            throw new IllegalArgumentException("Name cannot be null or empty.");
        }

        this.name = name;
    }

    @Override
    public abstract double getPrice();

    protected void setPrice(double price) {
        if (price < 0.0) {
            throw new IllegalArgumentException("Price cannot be negative or zero.");
        }

        this.priceOfProduct = price;
    }

    protected double getPriceOfProduct() {
        return this.priceOfProduct;
    }

    public int getQuantity() {
        return quantity;
    }

    private void setQuantity(int quantity) {
        if (quantity < 0) {
            throw new IllegalArgumentException("Quantity cannot be of negative value.");
        }

        this.quantity = quantity;
    }

    public void decreaseQuantityByOne() {
        this.setQuantity(1);
    }

    public AgeRestriction getAgeRestriction() {
        return ageRestriction;
    }

    protected void setAgeRestriction(AgeRestriction ageRestriction) {
        if (!AgeRestriction.isMember(ageRestriction.toString())) {
            throw new IllegalArgumentException("Invalid ageRestriction specified.");
        }

        this.ageRestriction = ageRestriction;
    }

    @Override
    public String toString() {
        return String.format("Product: name = '%s', price = $%.2f, quantity = %d, age restriction = %s",
                this.getName(), this.getPrice(), this.getQuantity(), this.getAgeRestriction());
    }
}
