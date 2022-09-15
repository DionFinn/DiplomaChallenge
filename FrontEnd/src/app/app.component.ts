import { Component } from '@angular/core';
import { Order } from './Models/Order';
import { Customer } from './Models/Customer';
import { Product } from './Models/Product';
import { Service } from './Services/service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title =  "Frontend"
  Orders : Order[] = [];
  Customers : Customer[] = [];
  Products : Product[] = [];
  createdOrder! : Order;
  selectedCustomer! : Customer;
  selectedProduct! : Product;
  selectedQty :  number = 0;
  selectedShipMode! : string;
  DeleteSelectedOrder! : Order;
  EditSelectedOrder! : Order;
  editedOrder! : Order;
   
  constructor (public _service : Service) {
    this.onInit();
  }

  onInit(){
    this._service.GetOrders()
    .subscribe(unpackedOrders => this.Orders = unpackedOrders, null, ()=>{
      this._service.GetCustomers()
      .subscribe(unpackedCustomers => this.Customers = unpackedCustomers, null, ()=>{
        this._service.GetProducts()
        .subscribe(unpackedProducts => this.Products = unpackedProducts, null, ()=>{
          
          
          this.EditSelectedOrder = this.Orders[0];
          this.editedOrder = {...this.EditSelectedOrder};
        });
      });
    });
    
    
  }

  addOrder(){
    this.createdOrder = {
      custID : this.selectedCustomer.custID,
      prod  : this.selectedProduct,
      orderDate : new Date().toString(),
      shipDate : "",
      quantity : this.selectedQty,
      shipMode : this.selectedShipMode
    }
    
    this._service.newOrder(this.createdOrder).subscribe(null,null,()=>{
      this.onInit
    })
  }
  
  deleteOrder(){
    this._service.deleteOrder(this.DeleteSelectedOrder).subscribe(null,null,()=>{
      this.onInit();
    })
  }

  editOrder(){
    this._service.deleteOrder(this.EditSelectedOrder).subscribe(null,null,()=>{
      this._service.newOrder(this.editedOrder).subscribe(null,null,()=>{
        this.onInit();
      })
    })
  }

  changedEdit(){
    this.editedOrder = {...this.EditSelectedOrder};
  }
}

 