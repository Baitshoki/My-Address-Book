import { Component, OnInit } from '@angular/core';
import { ContactDetailService } from 'src/app/shared/contact-detail.service';
import { ContactDetail } from 'src/app/shared/contact-detail.model';
import { ToastrService } from 'ngx-toastr';

//import { ContactDetailService } from './../../shared/contact-detail.service';

import { NgForm } from '@angular/forms';



@Component({
  selector: 'app-contact-detail-list',
  templateUrl: './contact-detail-list.component.html',
  styles: [ ]
})
export class ContactDetailListComponent implements OnInit {

 // constructor(private service: ContactDetailService) { }
  constructor(public service: ContactDetailService,  public toastr: ToastrService){}

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(cd:ContactDetail)
  {
      this.service.formData = Object.assign({},cd);
  }

  onDelete(ID)
  {
    if(confirm("Are you sure you want to delete?"))
    {
      this.service.deleteAddressBook(ID)
      .subscribe(res => {
      this.service.refreshList();
      this.toastr.warning("Deleted Successfully","Personal Address Book");
      },
      err=>{ 
        console.log(err);
      })
      }
    }

  }

  



