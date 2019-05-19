import { Component, OnInit } from '@angular/core';
import {DepartamentoService} from '../services/departamento.service';
import {Departamento} from '../models/departamento';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-departamento',
  templateUrl: './departamento.component.html',
  styleUrls: ['./departamento.component.css'],
  providers: [DepartamentoService]
})
export class DepartamentoComponent implements OnInit {

  public ltsdepartamentos:Departamento[]=[];
  public departamentos: Departamento = new Departamento(0,"","");
  public tempdepartamentos: Departamento = new Departamento(0,"","");
  NotificationStatus: boolean = false;
  TypeNotification: string = "success";
  TextNotification: string = "";
  ModalNotificationStatus: boolean = false;
  ModalTypeNotification: string = "success";
  ModalTextNotification: string = "";
  public active = true;
  public submitted = false;

  constructor(
    private _departamentoservice: DepartamentoService,
    private modalService: NgbModal
  ) { }

  ngOnInit() {
    this.getdepartamentos();
  }

  getdepartamentos() {
    this._departamentoservice.GetDepartamentoAll().subscribe(result => {
      this.ltsdepartamentos = result;
      console.log(this.ltsdepartamentos);
    }),
      error => console.error(error);
  }

  onClickInsertDepartamento() {
    this._departamentoservice.InsertDepartamento(this.departamentos).subscribe(
      result => {
        console.log(result);
        if (result.CodeError == 0) {
          this.NotificationStatus = true;
          this.TextNotification = result.DescriptionError;
          this.TypeNotification = "success";
          this.getdepartamentos();
        } else {
          this.NotificationStatus = true;
          this.TextNotification = result.DescriptionError;
          this.TypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }


  onClickUpdateDepartamento() {
    this._departamentoservice.UpdateDepartamento(this.tempdepartamentos).subscribe(
      result => {
        console.log(result);
        if (result.CodeError == 0) {
          this.ModalNotificationStatus = true;
          this.ModalTextNotification = result.DescriptionError;
          this.ModalTypeNotification = "success";
          this.getdepartamentos();
        } else {
          this.ModalNotificationStatus = true;
          this.ModalTextNotification = result.DescriptionError;
          this.ModalTypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }
  
  onClickDeteleDepartamento(IdDepartamento) {
    this._departamentoservice.DeleteDepartamento(IdDepartamento).subscribe(
      result => {
        console.log(result);
        if (result.CodeError == 0) {
          this.NotificationStatus = true;
          this.TextNotification = result.DescriptionError;
          this.TypeNotification = "success";
          this.getdepartamentos();
        } else {
          this.NotificationStatus = true;
          this.TextNotification = result.DescriptionError;
          this.TypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }

  OnClickCleanDepartamentos() {
    this.departamentos = new Departamento(0,"","");
  }

  //cerrar notificación
  closeAlert() {
    this.NotificationStatus = !this.NotificationStatus;
  }

    //cerrar notificación Modal
    closeAlertModal() {
      this.ModalNotificationStatus = !this.ModalNotificationStatus;
    }
  
  onClickEditarDepartamento(content,departamento) {
    this.tempdepartamentos=departamento;
    this.modalService.open(content, { size: 'lg' });
  }
}
