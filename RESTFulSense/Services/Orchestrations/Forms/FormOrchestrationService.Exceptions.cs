﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using RESTFulSense.Models.Foundations.Attributes.Exceptions;
using RESTFulSense.Models.Foundations.Forms.Exceptions;
using RESTFulSense.Models.Foundations.Values.Exceptions;
using RESTFulSense.Models.Orchestrations.Forms;
using RESTFulSense.Models.Orchestrations.Forms.Exceptions;

namespace RESTFulSense.Services.Orchestrations.Forms
{
    internal partial class FormOrchestrationService
    {
        private delegate FormModel ReturningFormModelFunction();

        private FormModel TryCatch(ReturningFormModelFunction returningFormModelFunction)
        {
            try
            {
                return returningFormModelFunction();
            }
            catch (NullFormModelException nullFormModelException)
            {
                var formOrchestrationValidationException =
                    new FormOrchestrationValidationException(nullFormModelException);

                throw formOrchestrationValidationException;
            }
            catch (NullStringContentException nullStringContentException)
            {
                var formOrchestrationValidationException =
                    new FormOrchestrationValidationException(nullStringContentException);

                throw formOrchestrationValidationException;
            }
            catch (AttributeValidationException attributeValidationException)
            {
                var formOrchestrationDependencyValidationException =
                    new FormOrchestrationDependencyValidationException(attributeValidationException);

                throw formOrchestrationDependencyValidationException;
            }
            catch (AttributeDependencyValidationException attributeDependencyValidationException)
            {
                var formOrchestrationDependencyValidationException =
                    new FormOrchestrationDependencyValidationException(attributeDependencyValidationException);

                throw formOrchestrationDependencyValidationException;
            }
            catch (ValueValidationException valueValidationException)
            {
                var formOrchestrationDependencyValidationException =
                    new FormOrchestrationDependencyValidationException(valueValidationException);

                throw formOrchestrationDependencyValidationException;
            }
            catch (ValueDependencyValidationException valueDependencyValidationException)
            {
                var formOrchestrationDependencyValidationException =
                    new FormOrchestrationDependencyValidationException(valueDependencyValidationException);

                throw formOrchestrationDependencyValidationException;
            }
            catch (FormValidationException formValidationException)
            {
                var formOrchestrationDependencyValidationException =
                    new FormOrchestrationDependencyValidationException(formValidationException);

                throw formOrchestrationDependencyValidationException;
            }
            catch (FormDependencyValidationException formDependencyValidationException)
            {
                var formOrchestrationDependencyValidationException =
                    new FormOrchestrationDependencyValidationException(formDependencyValidationException);

                throw formOrchestrationDependencyValidationException;
            }
            catch (AttributeDependencyException attributeDependencyException)
            {
                var formOrchestrationDependencyException =
                    new FormOrchestrationDependencyException(attributeDependencyException);

                throw formOrchestrationDependencyException;
            }
            catch (AttributeServiceException attributeServiceException)
            {
                var formOrchestrationDependencyException =
                    new FormOrchestrationDependencyException(attributeServiceException);

                throw formOrchestrationDependencyException;
            }
            catch (ValueDependencyException valueDependencyException)
            {
                var formOrchestrationDependencyException =
                    new FormOrchestrationDependencyException(valueDependencyException);

                throw formOrchestrationDependencyException;
            }
            catch (ValueServiceException valueServiceException)
            {
                var formOrchestrationDependencyException =
                    new FormOrchestrationDependencyException(valueServiceException);

                throw formOrchestrationDependencyException;
            }
            catch (FormDependencyException formDependencyException)
            {
                var formOrchestrationDependencyException =
                    new FormOrchestrationDependencyException(formDependencyException);

                throw formOrchestrationDependencyException;
            }
            catch (FormServiceException formServiceException)
            {
                var formOrchestrationDependencyException =
                    new FormOrchestrationDependencyException(formServiceException);

                throw formOrchestrationDependencyException;
            }
            catch (Exception exception)
            {
                var failedFormOrchestrationServiceException =
                    new FailedFormOrchestrationServiceException(exception);

                var formOrchestrationServiceException =
                    new FormOrchestrationServiceException(failedFormOrchestrationServiceException);

                throw formOrchestrationServiceException;
            }
        }
    }
}
