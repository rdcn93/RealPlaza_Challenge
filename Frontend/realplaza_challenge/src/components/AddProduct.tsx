import { Component, ChangeEvent } from "react";
import ProductDataService from "../services/product.service";
import IProductData from '../types/product.type';

type Props = {};

type Product = IProductData & {
   submitted: boolean
};

export default class AddProduct extends Component<Props, Product> {
  constructor(props: Props) {
    super(props);
    this.onChangeTitle = this.onChangeTitle.bind(this);
    this.onChangeDescription = this.onChangeDescription.bind(this);
    this.onChangePrice = this.onChangePrice.bind(this);
    this.onChangeDiscount = this.onChangeDiscount.bind(this);
    this.onChangeQuantity = this.onChangeQuantity.bind(this);
    this.saveProduct = this.saveProduct.bind(this);
    this.newProduct = this.newProduct.bind(this);

    this.state = {
      id: null,
      name: "",
      description: "",
      status: false,
      price: 0.0,
      discount: 0.0,
      quantity: 0,
      submitted: false
    };
  }

  onChangeTitle(e: ChangeEvent<HTMLInputElement>) {
    this.setState({
      name: e.target.value
    });
  }

  onChangeDescription(e: ChangeEvent<HTMLInputElement>) {
    this.setState({
      description: e.target.value
    });
  }

  onChangePrice(e: ChangeEvent<HTMLInputElement>) {
    this.setState({
      price: Number(e.target.value)
    });
  }

  onChangeDiscount(e: ChangeEvent<HTMLInputElement>) {
    this.setState({
      discount: Number(e.target.value)
    });
  }

  onChangeQuantity(e: ChangeEvent<HTMLInputElement>) {
    this.setState({
      quantity: parseInt(e.target.value)
    });
  }

  saveProduct() {
    const product: IProductData = {
        name: this.state.name,
        description: this.state.description,
        status: this.state.status,
        price: this.state.price,
        discount: this.state.discount,
        quantity: this.state.quantity
    };

    ProductDataService.create(product)
      .then((response: any) => {
        this.setState({
          id: response.data.id,
          name: response.data.name,
          description: response.data.description,
          status: response.data.status,
          price: response.data.price,
          discount: response.data.discount,
          quantity: response.data.quantity
        });
        console.log(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  }

  newProduct() {
    this.setState({
      id: null,
      name: "",
      description: "",
      status: true,
      price: 0.0,
      discount: 0.0,
      quantity: 0
    });
  }

  render() {
    const { submitted, name, description, price, discount, quantity } = this.state;

    return (
      <div className="submit-form">
        {submitted ? (
          <div>
            <h4>You submitted successfully!</h4>
            <button className="btn btn-success" onClick={this.newProduct}>
              Add
            </button>
          </div>
        ) : (
          <div>
            <div className="form-group">
              <label htmlFor="title">Name</label>
              <input
                type="text"
                className="form-control"
                id="title"
                required
                value={name}
                onChange={this.onChangeTitle}
                name="title"
              />
            </div>

            <div className="form-group">
              <label htmlFor="description">Description</label>
              <input
                type="text"
                className="form-control"
                id="description"
                required
                value={description}
                onChange={this.onChangeDescription}
                name="description"
              />
            </div>

            <div className="form-group">
              <label htmlFor="price">Price</label>
              <input
                type="number"
                className="form-control"
                id="price"
                required
                value={price}
                onChange={this.onChangePrice}
                name="price"
              />
            </div>

            <div className="form-group">
              <label htmlFor="discount">Discount</label>
              <input
                type="number"
                className="form-control"
                id="discount"
                required
                value={discount}
                onChange={this.onChangeDiscount}
                name="description"
              />
            </div>

            <div className="form-group">
              <label htmlFor="quantity">Quantity</label>
              <input
                type="number"
                className="form-control"
                id="quantity"
                required
                value={quantity}
                onChange={this.onChangeQuantity}
                name="description"
              />
            </div>

            <button onClick={this.saveProduct} className="btn btn-success">
              Submit
            </button>
          </div>
        )}
      </div>
    );
  }
}
