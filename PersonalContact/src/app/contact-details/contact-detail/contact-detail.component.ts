import { ContactDetailService } from './../../shared/contact-detail.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
////import { format } from 'path';
//import { ToastrService } from 'ngx-toastr';

//import { Component, OnInit } from '@angular/core';
//import { ContactDetailService } from 'src/app/shared/contact-detail.service';
import { ContactDetail } from 'src/app/shared/contact-detail.model';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-contact-detail',
  templateUrl: './contact-detail.component.html',
  styles: []
})
export class ContactDetailComponent implements OnInit 
{

  constructor(public service: ContactDetailService,  public  toastr: ToastrService){}

  ngOnInit()  {
    this.resetForm();
  }

  //ngOnInit():
  ////{
 //   this.resetForm();
 // }

  resetForm(form?: NgForm)
  {
    if (form != null)
      form.resetForm();
      

    this.service.formData = 
    {
        ID :0,
        FirstName : '',
        Surname : '',
        Telephone : '',
        CellNumber : '',
        EmailAddress : '',        
        UpdatedDate : ''

    }
  }

 onsubmit(form:NgForm)
 {
   if(this.service.formData.ID == 0)
     this.insertRecord(form);
   else
   //update
   this.updateRecord(form);
      
 }

 insertRecord(form:NgForm)
 {
  this.service.postAddressBook().subscribe(
    res => {
      this.resetForm(form);
      this.toastr.success("Address contact has been saved.");
      this.service.refreshList();
    },
    err => {
      console.log(err);
    }

  )

 }

 updateRecord(form:NgForm)
 {
  this.service.putAddressBook().subscribe(
    res => {
      this.resetForm(form);
      this.toastr.info("Address contact has been updated.");
      this.service.refreshList();
    },
    err => {
      console.log(err);
    }

  )

 }

 getRecordByFirstName(firstname)
 {
  this.service.getAddressBookByFirstName(firstname)
      .subscribe(res => {
      this.service.refreshList();
     
      },
      err=>{ 
        console.log(err);
      }
      )
      
    }

    getRecordBySurname(surname)
    {
     this.service.getAddressBookBySurname(surname)
         .subscribe(res => {
         this.service.refreshList();
       
         },
         err=>{ 
           console.log(err);
         }
         )
         
       }
  
 

}
