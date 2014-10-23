package com.softuni.oop.onelevshop;

public class Appliance extends ElectronicsProduct{
    private static final int APPLIANCE_GUARANTEE = 6;
    private static final int MAXIMAL_APPLIANCE_FOR_EXTRA_CHARGE = 50;

    protected Appliance(String name, double price, int quantity, AgeRestriction ageRestriction) {
        super(name, price, quantity, ageRestriction, APPLIANCE_GUARANTEE);
    }

    @Override
    public double getPrice() {
        if (this.getQuantity() < MAXIMAL_APPLIANCE_FOR_EXTRA_CHARGE) {
            return this.getPriceOfProduct() * 1.05;
        }

        return super.getPriceOfProduct();
    }
}
