import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Subject } from 'rxjs';
import { ContactSubject } from '../../enums/contact-subject.enum';
import intlTelInput from 'intl-tel-input';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.css'
})

export class ContactComponent implements OnInit,AfterViewInit{
  constructor(private route: ActivatedRoute , private router: Router) {}

  ContactSubject = ContactSubject;

  contactForm = new FormGroup({
    nameSurname: new FormControl<string>(''),
    phone: new FormControl<string>(''),
    email: new FormControl<string>(''),
    subject: new FormControl<ContactSubject>(ContactSubject.Bilgi),
    message: new FormControl<string>(''),
  });
  
    // Enum to string mapping
  subjectMap: { [key : number]: string } = {
      [ContactSubject.Bilgi]: 'Bilgi',
      [ContactSubject.Oneri]: 'Öneri',
      [ContactSubject.Sikayet]: 'Şikayet',
  };

  @ViewChild('phoneInput' ,{ static: false }) phoneInput!: ElementRef; // Input alanına referans

  ngAfterViewInit() {
    // intl-tel-input'ı başlatma
    intlTelInput(this.phoneInput.nativeElement, {
      initialCountry: 'tr', // Varsayılan ülke kodunu ayarlayın
      utilsScript: 'https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/17.0.8/js/utils.js' // Gelişmiş doğrulama için
    });


  }
  onFormSubmit() {
  }

  ngOnInit(): void {
      // Fragment değişikliklerini dinler
      this.route.fragment.subscribe(fragment => {
        if (fragment) {
          this.goToFragment(fragment);
        }
      });
    }

  goToFragment(fragmentId: string) {
    // Önce null fragment ile yönlendir, ardından hedef fragmente kaydır
    this.router.navigate([], { fragment: undefined, replaceUrl: true }).then(() => {
      setTimeout(() => {
        const element = document.getElementById(fragmentId);
        if (element) {
          element.scrollIntoView({ behavior: 'smooth', block: 'start' });
        }
      }, 0);
    });
  }

}