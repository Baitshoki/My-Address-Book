import { ContactDetail } from './contact-detail.model'
import { Injectable } from '@angular/core';
import { from } from 'rxjs';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ContactDetailService
{
  formData:ContactDetail
  readonly rootURL = 'http://localhost:49834/api';
  list: ContactDetail[];

  constructor(private http:HttpClient) { }

  postAddressBook()
  {
   return this.http.post(this.rootURL+'/AddressBook',this.formData)
  }


  putAddressBook()
  {
   return this.http.put(this.rootURL+'/AddressBook/'+ this.formData.ID, this.formData)
  }

  deleteAddressBook(id)
  {
   return this.http.delete(this.rootURL+'/AddressBook/'+ id)
  }

  getAddressBookByFirstName(firstname)
  {
   return this.http.delete(this.rootURL+'/AddressBook/'+ firstname)
  }

  getAddressBookBySurname(surname)
  {
   return this.http.delete(this.rootURL+'/AddressBook/'+ surname)
  }
  
  refreshList()
  {
    this.http.get(this.rootURL+'/AddressBook')
    .toPromise()
    .then(res => this.list = res as ContactDetail[]);
  }
}
