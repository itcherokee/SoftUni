package com.softuni.oop.geometry;

public class SquarePyramid extends SpaceShape {
    private double baseWidth;
    private double baseHeight;

    public SquarePyramid(Point3D vertex, double baseWidth, double baseHeight) {
        super(vertex);
        this.setBaseWidth(baseWidth);
        this.setBaseHeight(baseHeight);
    }

    public double getBaseWidth() {
        return this.baseWidth;
    }

    private void setBaseWidth(double baseWidth) {
        if (baseWidth <= 0.0) {
            throw new IllegalArgumentException("Invalid width - cannot be of negative or zero value.");
        }

        this.baseWidth = baseWidth;
    }

    public double getBaseHeight() {
        return this.baseHeight;
    }

    private void setBaseHeight(double baseHeight) {
        if (baseHeight <= 0.0) {
            throw new IllegalArgumentException("Invalid height - cannot be of negative or zero value.");
        }

        this.baseHeight = baseHeight;
    }

    @Override
    public double getArea() {
        return (this.getBaseWidth() * this.getBaseWidth()) + 2 * this.getBaseWidth() *
                Math.sqrt((this.getBaseWidth() * this.getBaseWidth() / 4) +
                        (this.getBaseHeight() * this.getBaseHeight()));
    }

    @Override
    public double getVolume() {
        return this.getBaseWidth() * this.getBaseWidth() * (this.getBaseHeight() / 3);
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder();
        output.append("Shape type: Pyramid\n");
        output.append(super.toString());

        return output.toString();
    }
}
